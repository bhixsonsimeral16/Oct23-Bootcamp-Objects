using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : Pickup, IDamageable
{
    [SerializeField] float fireRateIncrease = 0.1f;
    [SerializeField] float fireRateDuration = 5f;

    public override void OnPickedUp()
    {
        GameManager.GetInstance().GetPlayer().ActivateRapidFire(fireRateIncrease, fireRateDuration);
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
