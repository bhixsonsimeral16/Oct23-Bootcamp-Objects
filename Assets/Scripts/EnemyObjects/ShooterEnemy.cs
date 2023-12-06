using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterEnemy : Enemy
{
    public override void BattleCry()
    {
        Debug.Log("Boom! Headshot!");
    }
}
