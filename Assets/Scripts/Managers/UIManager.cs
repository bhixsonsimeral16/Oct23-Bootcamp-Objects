using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Gameplay")]
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text highScoreText;
    [SerializeField] TMP_Text nukeCountText;

    [Header("Menu")]
    [SerializeField] GameObject menuCanvas;
    [SerializeField] GameObject labelGameOver;
    [SerializeField] TMP_Text textMenuHighScore;

    Player player;
    ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        menuCanvas.SetActive(true);
        scoreManager = GameManager.GetInstance().scoreManager;

        GameManager.GetInstance().OnGameStart += GameStarted;
        GameManager.GetInstance().OnGameEnd += GameEnded;
    }

    void UpdateHealth(float currentHealth)
    {
        healthText.SetText($"{Mathf.Floor(currentHealth)}");
    }

    public void UpdateScore()
    {
        scoreText.SetText(scoreManager.GetScore().ToString());
    }

    public void UpdateHighScore()
    {
        highScoreText.SetText(scoreManager.GetHighScore().ToString());
        textMenuHighScore.SetText($"High Score: {scoreManager.GetHighScore()}");
    }

    void UpdateNukeCount(int nukeCount)
    {
        nukeCountText.SetText(nukeCount.ToString());
    }

    public void GameStarted()
    {
        player = GameManager.GetInstance().GetPlayer();
        player.health.OnHealthUpdate += UpdateHealth;
        player.OnNukeUpdate += UpdateNukeCount;


        menuCanvas.SetActive(false);
    }

    public void GameEnded()
    {
        menuCanvas.SetActive(true);
        labelGameOver.SetActive(true);
    }
}
