using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText, healthText;
    [SerializeField] Player player;
    // Start is called before the first frame update
    void Start()
    {
        healthText.SetText($"{player.health.currentHealth}");

        // Subscribe to the event
        player.OnHealthUpdate += UpdateHealth;
    }

    void OnDisable()
    {
        // Unsubscribe from the event
        player.OnHealthUpdate -= UpdateHealth;    
    }

    void UpdateHealth(float currentHealth)
    {
        healthText.SetText($"{Mathf.Floor(currentHealth)}");
    }

    public void UpdateScore()
    {
        scoreText.SetText(GameManager.GetInstance().scoreManager.GetScore().ToString());
    }
}
