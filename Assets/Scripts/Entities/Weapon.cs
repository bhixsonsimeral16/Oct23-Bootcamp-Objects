using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon
{
    string name;
    float coolDownTime;
    float coolDownTimer = 0f;
    float accuracyArcMax = 45f;

    public float bulletSpeed;
    public float damage;
    public float RPS = 4;
    public float accuracy = 1f;

    public Weapon()
    {
        coolDownTime = 1f / RPS;
    }

    public Weapon(string _name, float _damage, float _bulletSpeed = 10f, float _RPS = 4, float _accuracy = 1f)
    {
        name = _name;
        damage = _damage;
        bulletSpeed = _bulletSpeed;
        this.RPS = _RPS;
        accuracy = _accuracy;
        
        // No cooldown
        if (RPS <= 0)
        {
            coolDownTime = 0f;
        }

        // Cooldown
        else
        {
            coolDownTime = 1f / RPS;
        }
    }

    public void PlayerShoot(float timeSinceLastShot, Bullet bullet, PlayableObjects player, string targetTag, float timeToDie = 5f)
    {
        coolDownTimer += timeSinceLastShot;
        Shoot(bullet, player, targetTag, timeToDie);
    }

    public void Shoot(Bullet bullet, PlayableObjects player, string targetTag, float timeToDie = 5f)
    {
        if (RPS <= 0)
        {
            throw new System.Exception("Weapon can not shoot when RPS is 0 or less");
        }
        if (coolDownTimer < coolDownTime)
        {
            coolDownTimer += Time.deltaTime;
            return;
        }
        // Accuracy arc is from -accuracyArcMax to accuracyArcMax degrees
        // 1f accuracy is perfect accuracy
        float bulletTransformRotation = Random.Range(-accuracyArcMax + (accuracy * accuracyArcMax),  accuracyArcMax - (accuracy * accuracyArcMax));

        coolDownTimer = 0f;
        Debug.Log("Weapon is shooting");
        Bullet bulletObj = GameObject.Instantiate(bullet, player.transform.position, player.transform.rotation);
        bulletObj.transform.Rotate(0, 0, bulletTransformRotation);
        bulletObj.SetBullet(damage, targetTag, bulletSpeed);

        GameObject.Destroy(bulletObj.gameObject, timeToDie);
        
    }

    public float GetDamage()
    {
        return damage;
    }
}
