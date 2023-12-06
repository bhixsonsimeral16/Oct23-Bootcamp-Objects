using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploderEnemy : Enemy
{
    public override void BattleCry()
    {
        Debug.Log("Watch out for my explosion!");
    }
}
