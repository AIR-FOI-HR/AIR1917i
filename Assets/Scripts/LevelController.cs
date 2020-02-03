using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class LevelController : MonoBehaviour
{


    public string url;
    static AssetBundle assetBundle;
    static string[] scenes;

    //za prikaz statusa mreže
    GameObject networkStatusImage;
    Image image;

    GameObject networkStatusText;
    Text networkText;

    public static LevelController instance;

    private void Awake()
    {
        networkStatusImage = GameObject.FindGameObjectWithTag("Network Status");
        networkText = GameObject.Find("Network Text").GetComponent<Text>();
        if (networkStatusImage != null)
        {
            image = networkStatusImage.GetComponent<Image>();
            image.enabled = false; 
           
        }
        if (networkText != null)
        {
            networkText.enabled = false;
        }
       
    }

  

    public static IEnumerator WaitForRealSeconds(float time)
    {


        float start = Time.realtimeSinceStartup;

        while (Time.realtimeSinceStartup < (start + time))
        {
            yield return null;
        }
    }

    IEnumerator Start()
    {

        //if (!assetBundle)
        //{
        //    Debug.Log("vec postoji asset bundle");

        //     yield return null;
        //}
        // Debug.Log("helloo");
        //      using (WWW www = new WWW(url))
        //      {
        //          yield return www;
        //          if (!string.IsNullOrEmpty(www.error))
        //          {
        //              Debug.LogError(www.error);
        //              yield break;
        //          }
        //        if (assetBundle == null)
        //        {
        //            Debug.Log("ovo je novo");
        //            assetBundle = www.assetBundle;
        //        } 


        //      }


        //   scenes = assetBundle.GetAllScenePaths();

        //  foreach (string scenename in scenes)
        //  {
        //      Debug.Log(Path.GetFileNameWithoutExtension(scenename));
        // }  

        if (Application.internetReachability == NetworkReachability.NotReachable) {
            GameObject networkStatusImage = GameObject.FindGameObjectWithTag("Network Status");        
            image.enabled = true;
            networkText.enabled = true;
        }

        else
        {
            if (assetBundle != null)
            {
                assetBundle.Unload(true); //scene is unload from here
            }

            while (!Caching.ready)
            {

                yield return null;
            }



            WWW www = WWW.LoadFromCacheOrDownload(url, 1);
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.Log(www.error);
                yield return null;
            }

            assetBundle = www.assetBundle;
            scenes = assetBundle.GetAllScenePaths();
            foreach (string scenename in scenes)
            {
                Debug.Log(Path.GetFileNameWithoutExtension(scenename));
            }
        }

        

    }

    public void PokreniLevel2()
    {

        if(image.enabled==false)
           SceneManager.LoadScene(Path.GetFileNameWithoutExtension(scenes[0]));

    }

    public void PokreniLevel3()
    {

        if(image.enabled==false)
            SceneManager.LoadScene(Path.GetFileNameWithoutExtension(scenes[1]));

    }





    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("Glavna Scena");
    }

    public void LoadLevel1()
    {

        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("Level One");
    }

    public void LoadLevel2()
    {

        if (GamePreferences.GetEasyDifficultyCoinScore() > 10)
        {
            GameManager.instance.gameStartedFromMainMenu = true;
            PokreniLevel2();
        }

    }

    public void LoadLevel3()
    {
        if (GamePreferences.GetEasyDifficultyCoinScore() > 20)
        {
            GameManager.instance.gameStartedFromMainMenu = true;
            PokreniLevel3();
        }

    }
}
