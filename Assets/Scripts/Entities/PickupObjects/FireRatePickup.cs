using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireRatePickup : Pickup, IDamageable
{
    public override void OnPickedUp()
    {
        // TODO: Implement increased fire rate
        
        GameManager.GetInstance().GetPlayer();
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
