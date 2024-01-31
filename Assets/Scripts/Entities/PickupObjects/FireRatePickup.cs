using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : Pickup, IDamageable
{
    [SerializeField] float fireRateMultiplier = 1.5f;
    // I currently have the duration of an animation at 5 seconds and it is not
    // directly connected to the fire rate duration. From my reseach I found that
    // I can't use animator if I want a variable duration.
    float fireRateDuration = 5f;

    public override void OnPickedUp()
    {
        GameManager.GetInstance().GetPlayer().ActivateRapidFire(fireRateMultiplier, fireRateDuration);
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
