using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading;

public class Player : PlayableObjects
{
    [SerializeField] float speed;
    [SerializeField] Camera cam;
    [SerializeField] float weaponDamage = 1f;
    [SerializeField] float weaponBulletSpeed = 10f;
    [SerializeField] Bullet bulletPrefab;
    [SerializeField] Rigidbody2D playerRB;
    [SerializeField] string targetTag = "Enemy";
    [SerializeField] GameObject outlineCircle;

    public Action OnDeath;

    string nickName;
    float timeSinceLastShot;

    //public Action<float> OnHealthUpdate;

    void Awake()
    {
        health = new Health(100f, 1f);
        playerRB = GetComponent<Rigidbody2D>();

        weapon = new Weapon("Player Weapon", weaponDamage, weaponBulletSpeed);

        timeSinceLastShot = 0;

        cam = Camera.main;
    }

    void Update()
    {
        health.RegenHealth();
        timeSinceLastShot += Time.deltaTime;

        ChangeOutlineColor();
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
        weapon.PlayerShoot(timeSinceLastShot, bulletPrefab, this, targetTag);
        timeSinceLastShot = 0;
    }

    public override void Die()
    {
        Debug.Log("Player is dead");
        Destroy(gameObject);
        OnDeath?.Invoke();
    }

    public override void Attack(float interval)
    {
        
    }

    public override void TakeDamage(float damage)
    {
        Debug.Log("Player is taking damage");
        health.TakeDamage(damage);

        if(health.currentHealth <= 0)
        {
            Die();
        }
    }

    void ChangeOutlineColor()
    {
        // Ocilate the color of the outline circle in a rainbow pattern
        var color = Color.HSVToRGB(Mathf.PingPong(Time.time, 1), 1, 1);
        outlineCircle.GetComponent<SpriteRenderer>().color = color;
    }
}
