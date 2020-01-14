using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePreferences {

    public static string EasyDifficulty = "EasyDifficulty";

    public static string EasyDifficultyHighScore = "EasyDifficultyHighScore";

    public static string EasyDifficultyCoinScore = "EasyDifficultyCoinScore";

    public static string IsMusicOn = "IsMusicOn";

    public static int GetMusicState()
    {
        return PlayerPrefs.GetInt(GamePreferences.IsMusicOn);
    }

    public static void SetMusicState(int state)
    {
        PlayerPrefs.SetInt(GamePreferences.IsMusicOn, state);
    }

    public static void SetEasyDifficultyState(int difficulty)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficulty, difficulty);
    }

    public static int GetEasyDifficultyState()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficulty);
    }

    //HighScore
    public static void SetEasyDifficultyHighScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyHighScore, score);
    }

    public static int GetEasyDifficultyHighScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyHighScore);
    }

    //CoinScore

    public static void SetEasyDifficultyCoinScore(int score)
    {
        PlayerPrefs.SetInt(GamePreferences.EasyDifficultyCoinScore, score);
    }

    public static int GetEasyDifficultyCoinScore()
    {
        return PlayerPrefs.GetInt(GamePreferences.EasyDifficultyCoinScore);
    }
}
