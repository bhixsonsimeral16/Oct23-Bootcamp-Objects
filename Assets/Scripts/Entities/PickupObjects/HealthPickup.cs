using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{
    [SerializeField] float healthAmount = 5f;

    public override void OnPickedUp()
    {
        GameManager.GetInstance().GetPlayer().health.Heal(healthAmount);
        base.OnPickedUp();
    }

    public void TakeDamage(float damage)
    {
        OnPickedUp();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            OnPickedUp();
        }
    }
}
