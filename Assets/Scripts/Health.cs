using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    public float currentHealth {get; private set;}
    float maxHealth;
    float healthRegenRate;
    
    public Health()
    {
        currentHealth = 100f;
        maxHealth = 100f;
        healthRegenRate = 1f;
    }

    public Health(float maxHealth, float healthRegenRate)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.healthRegenRate = healthRegenRate;
    }

    public Health(float currentHealth, float maxHealth, float healthRegenRate)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        this.healthRegenRate = healthRegenRate;
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Max(currentHealth + amount, currentHealth);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Min(currentHealth - amount, currentHealth);
    }

    // For use in Update()
    // Regen Health over time
    public void RegenHealth()
    {
        Heal(healthRegenRate * Time.deltaTime);
    }
}
