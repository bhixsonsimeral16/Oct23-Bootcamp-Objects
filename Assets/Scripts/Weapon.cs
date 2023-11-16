using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    string name;
    float damage;

    public Weapon()
    {
        
    }

    public Weapon(string _name, float _damage)
    {
        name = _name;
        damage = _damage;
    }

    public void Shoot()
    {
        Debug.Log("Weapon is shooting");
    }
}
