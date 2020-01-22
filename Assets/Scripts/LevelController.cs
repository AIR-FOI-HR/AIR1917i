using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;

public class LevelController : MonoBehaviour
{


    public string url;
    static AssetBundle assetBundle;
    static string[] scenes;

    public static LevelController instance;

    private void Awake()
    {

        //StartCoroutine(WaitForRealSeconds(100000));
        Debug.Log("awake method");
        //StartCoroutine(Start());
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

    public void PokreniLevel2()
    {

        SceneManager.LoadScene(Path.GetFileNameWithoutExtension(scenes[0]));

    }

    public void PokreniLevel3()
    {

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
