using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    string nickName;
    float speed;
    public Health health = new Health();
    public Weapon weapon;

    public void Move(Vector3 direction)
    {
        Debug.Log("Player is moving");
    }

    public void Shoot(Vector3 direction, float bulletSpeed)
    {
        Debug.Log("Player is shooting");
    }

    public void Die()
    {
        Debug.Log("Player is dead");
    }
}
