using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    string name;
    float damage;
    float bulletSpeed;
    float RPS = 4;
    float coolDownTime;
    float coolDownTimer = 0f;

    public Weapon()
    {
        coolDownTime = 1f / RPS;
    }

    public Weapon(string _name, float _damage, float _bulletSpeed = 10f, float _RPS = 4)
    {
        name = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
        this.RPS = _RPS;
        coolDownTime = 1f / RPS;
    }

    public void Shoot(Bullet bullet, PlayableObjects player, string targetTag, float timeToDie = 5f)
    {
        if (coolDownTimer < coolDownTime)
        {
            coolDownTimer += Time.deltaTime;
            return;
        }
        coolDownTimer = 0f;
        Debug.Log("Weapon is shooting");
        Bullet bulletObj = GameObject.Instantiate(bullet, player.transform.position, player.transform.rotation);
        bulletObj.SetBullet(damage, targetTag, bulletSpeed);

        GameObject.Destroy(bulletObj.gameObject, timeToDie);
        
    }

    public float GetDamage()
    {
        return damage;
    }
}
