using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NukePickup : Pickup, IDamageable
{
    public override void OnPickedUp()
    {
        GameManager.GetInstance().GetPlayer().AddNuke();
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
