using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
{
    float speed;
    float damage;

    void Move(Transform target)
    {
        Debug.Log("Bullet is moving");
    }

    void Damage()
    {
        Debug.Log("Bullet is damaging");
    }
}
