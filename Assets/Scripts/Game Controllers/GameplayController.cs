using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayController : MonoBehaviour
{

    public static GameplayController instance;

    [SerializeField]
    private Text scoreText, coinText, lifeText, gameOverScoreText, gameOverCoinText;

    [SerializeField]
    private GameObject pausePanel, gameOverPanel;

    [SerializeField]
    private GameObject readyButton;

    // Use this for initialization
    void Awake()
    {
        MakeInstance();
    }

    private void Start()
    {
        Time.timeScale = 0f;
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void GameOverShowPanel(int finalScore, int finalCoinScore)
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = finalScore.ToString();
        gameOverCoinText.text = finalCoinScore.ToString();
        StartCoroutine(GameOverLoadMainMenu());

    }

    IEnumerator GameOverLoadMainMenu()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("Glavna scena");
    }

    public void PlayerDiedRestartTheGame()
    {
        StartCoroutine(PlayerDiedRestard());
    }

    IEnumerator PlayerDiedRestard()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level One");
    }

    //novo za 2 i 3 level 
    public void PlayerDiedRestartTheGameLevel2()
    {
        StartCoroutine(PlayerDiedRestardL2());
    }

    IEnumerator PlayerDiedRestardL2()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level 2");
    }

    public void PlayerDiedRestartTheGameLevel3()
    {
        StartCoroutine(PlayerDiedRestardL3());
    }

    IEnumerator PlayerDiedRestardL3()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("Level 3");
    }

    public void SetScore(int score)
    {
        scoreText.text = "x" + score;
    }

    public void SetCoinScore(int coinScore)
    {
        coinText.text = "x" + coinScore;
    }

    public void SetLifeScore(int lifeScore)
    {
        lifeText.text = "x" + lifeScore;
    }

    public void PauseTheGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }


    public void ResumeGame()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Glavna Scena");
    }

    public void StartTheGame()
    {
        Time.timeScale = 1f;
        readyButton.SetActive(false);
    }


}
