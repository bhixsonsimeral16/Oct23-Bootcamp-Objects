using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health
{
    public float currentHealth {get; private set;}
    float maxHealth;
    float healthRegenRate;
    
    public Action<float> OnHealthUpdate;
    public Health()
    {
        currentHealth = 100f;
        maxHealth = 100f;
        healthRegenRate = 1f;

        OnHealthUpdate?.Invoke(currentHealth);
    }

    public Health(float maxHealth, float healthRegenRate)
    {
        this.maxHealth = maxHealth;
        currentHealth = maxHealth;
        this.healthRegenRate = healthRegenRate;

        OnHealthUpdate?.Invoke(currentHealth);
    }

    public Health(float currentHealth, float maxHealth, float healthRegenRate)
    {
        this.currentHealth = currentHealth;
        this.maxHealth = maxHealth;
        this.healthRegenRate = healthRegenRate;

        OnHealthUpdate?.Invoke(currentHealth);
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Max(currentHealth + amount, currentHealth);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        OnHealthUpdate?.Invoke(currentHealth);
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Min(currentHealth - amount, currentHealth);
        OnHealthUpdate?.Invoke(currentHealth);
    }

    // For use in Update()
    // Regen Health over time
    public void RegenHealth()
    {
        Heal(healthRegenRate * Time.deltaTime);
    }
}
