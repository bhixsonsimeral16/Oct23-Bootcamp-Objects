using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : PlayableObjects
{
    string nickName;
    [SerializeField] float speed;
    [SerializeField] Camera cam;
    [SerializeField] float weaponDamage = 1f;
    [SerializeField] float weaponBulletSpeed = 10f;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] string targetTag = "Enemy";

    public Action<float> OnHealthUpdate;

    void Start()
    {
        health = new Health(100f, 1f);
        playerRB = GetComponent<Rigidbody2D>();

        weapon = new Weapon("Player Weapon", weaponDamage, weaponBulletSpeed);

        OnHealthUpdate?.Invoke(health.currentHealth);
    }

    void Update()
    {
        health.RegenHealth();
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRB.velocity = direction * speed * Time.deltaTime;

        var playerScreenPosition = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPosition.x;
        target.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public override void Shoot()
    {
        Debug.Log("Player is shooting");
        weapon.Shoot(bulletPrefab, this, targetTag);
    }

    public override void Die()
    {
        Debug.Log("Player is dead");
        Destroy(gameObject);
    }

    public override void Attack(float interval)
    {
        
    }

    public override void TakeDamage(float damage)
    {
        Debug.Log("Player is taking damage");
        health.TakeDamage(damage);

        OnHealthUpdate?.Invoke(health.currentHealth);
        if(health.currentHealth <= 0)
        {
            Die();
        }
    }
}
