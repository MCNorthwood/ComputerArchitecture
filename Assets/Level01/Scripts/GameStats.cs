﻿using UnityEngine;
using UnityEngine.UI;

public class GameStats : MonoBehaviour {

    public static int EnemiesKilled;

    public static string PlayerName = "E-Learner";

    public Text[] highScores;

    int[] highScoreValues;
    string[] highScoreNames;

	void Start ()
    {
        EnemiesKilled = 0;
        highScoreValues = new int[highScores.Length];
        highScoreNames = new string[highScores.Length];

        for (int i = 0; i < highScores.Length; i++)
        {
            highScoreValues[i] = PlayerPrefs.GetInt("highScoreValues" + i);
            highScoreNames[i] = PlayerPrefs.GetString("highScoreNames" + i);
        }
	}

    void SaveScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            PlayerPrefs.SetInt("highScoreValues" + i, highScoreValues[i]);
            PlayerPrefs.SetString("highScoreNames" + i, highScoreNames[i]);
        }
    }

    void DrawScores()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            highScores[i].text = highScoreNames[i] + ": " + highScoreValues[i].ToString();
        }
    }

    public void CheckForHighScore()
    {
        for (int i = 0; i < highScores.Length; i++)
        {
            if(EnemiesKilled > highScoreValues[i])
            {
                for (int j = highScores.Length - 1; j > i; j--)
                {
                    highScoreValues[j] = highScoreValues[j - 1];
                    highScoreNames[j] = highScoreNames[j - 1];
                }

                highScoreValues[i] = EnemiesKilled;
                highScoreNames[i] = PlayerName;
                DrawScores();
                SaveScores();
                break;
            }
        }
    }
}