using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{
    public override void BattleCry()
    {
        Debug.Log("Kneel before me!");
    }
}
