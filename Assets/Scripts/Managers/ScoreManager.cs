using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public UnityEvent OnScoreUpdated;
    public UnityEvent OnHighScoreUpdated;

    public const string highScoreKey = "HighScore";

    int highScore;

    void Start()
    {
        highScore = PlayerPrefs.GetInt(highScoreKey, 0);
        OnHighScoreUpdated?.Invoke();

        GameManager.GetInstance().OnGameStart += OnGameStart;
    }

    public int GetScore()
    {
        return score;
    }

    public void SetHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            OnHighScoreUpdated?.Invoke();
        }

        PlayerPrefs.SetInt(highScoreKey, highScore);
    }

    public int GetHighScore()
    {
        return highScore;
    }

    public void IncrementScore()
    {
        score ++;
        OnScoreUpdated?.Invoke();
    }

    public void OnGameStart()
    {
        score = 0;
        OnScoreUpdated?.Invoke();
    }
}
