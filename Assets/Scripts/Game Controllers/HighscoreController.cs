using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HighscoreController : MonoBehaviour {

    [SerializeField]
    private Text scoreText, coinText;

    // Use this for initialization
    void Start () {
        SetScoreBasedOnDifficulty();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void SetScore(int score, int coinScore)
    {
        scoreText.text = score.ToString();
        coinText.text = coinScore.ToString();
    }

    void SetScoreBasedOnDifficulty()
    {
        if (GamePreferences.GetEasyDifficultyState() == 1)
        {
            SetScore(GamePreferences.GetEasyDifficultyHighScore(), GamePreferences.GetEasyDifficultyCoinScore());
        }
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("Glavna Scena");
    }
}
