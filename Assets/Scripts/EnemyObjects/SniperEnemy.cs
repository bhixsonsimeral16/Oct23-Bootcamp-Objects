using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : Enemy
{
    public override void BattleCry()
    {
        Debug.Log("They never saw me coming!");
    }
}
