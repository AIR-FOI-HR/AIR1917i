using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {
    
    [SerializeField]
    private Button musicBtn;

    [SerializeField]
    private Sprite[] musicIcons;

    // Use this for initialization
    void Start () {
        CheckToPlayTheMusic();
    }

    void CheckToPlayTheMusic()
    {
        if (GamePreferences.GetMusicState() == 1)
        {
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }
        else
        {
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void StartGame()
    {
        GameManager.instance.gameStartedFromMainMenu = true;
        SceneManager.LoadScene("Level One");

    }

    public void HighscoreMenu()
    {
        SceneManager.LoadScene("Highscore Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MusicButton()
    {
        if (GamePreferences.GetMusicState() == 0)
        {
            GamePreferences.SetMusicState(1);
            MusicController.instance.PlayMusic(true);
            musicBtn.image.sprite = musicIcons[1];
        }
        else if (GamePreferences.GetMusicState() == 1)
        {
            GamePreferences.SetMusicState(0);
            MusicController.instance.PlayMusic(false);
            musicBtn.image.sprite = musicIcons[0];
        }
    }
}
