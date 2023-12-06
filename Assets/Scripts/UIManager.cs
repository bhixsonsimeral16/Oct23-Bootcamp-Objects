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
        player.OnHealthUpdate += UpdateHealth;
    }

    void OnDisable()
    {
        player.OnHealthUpdate -= UpdateHealth;    
    }

    void UpdateHealth(float currentHealth)
    {
        healthText.SetText($"{currentHealth}");
    }
}
