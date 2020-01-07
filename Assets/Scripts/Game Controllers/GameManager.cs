using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

    [HideInInspector]
    public bool gameStartedFromMainMenu, gameRestartedAfterPlayerDied;

    [HideInInspector]
    public int score, coinScore, lifeScore;

    void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        InitializeVariables();
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    

    void OnLevelWasLoaded()
    {
        if (SceneManager.GetActiveScene().name == "Level One")
        {
            if (gameRestartedAfterPlayerDied)
            {
                GameplayController.instance.SetScore(score);
                GameplayController.instance.SetCoinScore(coinScore);
                GameplayController.instance.SetLifeScore(lifeScore);

                PlayerScore.scoreCount = score;
                PlayerScore.coinCount = coinScore;
                PlayerScore.lifeCount = lifeScore;

            }
            else if (gameStartedFromMainMenu)
            {
                PlayerScore.scoreCount = 0;
                PlayerScore.coinCount = 0;
                PlayerScore.lifeCount = 2;

                GameplayController.instance.SetScore(0);
                GameplayController.instance.SetCoinScore(0);
                GameplayController.instance.SetLifeScore(2);
            }
        }
    }

    void InitializeVariables()
    {
        if (!PlayerPrefs.HasKey("Game Initialized"))
        {

            GamePreferences.SetEasyDifficultyState(1);
            GamePreferences.SetEasyDifficultyCoinScore(0);
            GamePreferences.SetEasyDifficultyHighScore(0);
            
            GamePreferences.SetMusicState(0);

            PlayerPrefs.SetInt("Game Initialized", 123);
        }
    }

    public void CheckGameStatus(int score, int coinScore, int lifeScore)
    {
        if (lifeScore < 0)
        {
            if (GamePreferences.GetEasyDifficultyState() == 1)
            {

                int highScore = GamePreferences.GetEasyDifficultyHighScore();
                int coinHighScore = GamePreferences.GetEasyDifficultyCoinScore();

                if (highScore < score)
                    GamePreferences.SetEasyDifficultyHighScore(score);

                if (coinHighScore < coinScore)
                    GamePreferences.SetEasyDifficultyCoinScore(coinScore);
            }

            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = false;

            GameplayController.instance.GameOverShowPanel(score, coinScore);

        }
        else
        {
            this.score = score;
            this.coinScore = coinScore;
            this.lifeScore = lifeScore;
            
            gameStartedFromMainMenu = false;
            gameRestartedAfterPlayerDied = true;

            GameplayController.instance.PlayerDiedRestartTheGame();
        }
    }
}
