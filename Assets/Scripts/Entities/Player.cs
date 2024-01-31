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
    // [SerializeField] GameObject rapidFireCircle;
    [SerializeField] Animator playerAnimator;
    [SerializeField] ParticleSystem nukeParticles;

    public Action OnDeath;

    float timeSinceLastShot;
    int nukeCounter = 1;
    float rapidFireTimer = 0f;
    float fireRateMultiplier = 1f;

    public Action<int> OnNukeUpdate;

    //public Action<float> OnHealthUpdate;

    void Awake()
    {
        health = new Health(100f, 1f);
        playerRB = GetComponent<Rigidbody2D>();

        weapon = new Weapon("Player Weapon", weaponDamage, weaponBulletSpeed);

        timeSinceLastShot = 0;

        cam = Camera.main;
    }

    void Start()
    {
        OnNukeUpdate?.Invoke(nukeCounter);
    }
    void Update()
    {
        health.RegenHealth();
        timeSinceLastShot += Time.deltaTime;
        if (rapidFireTimer > 0)
        {
            rapidFireTimer -= Time.deltaTime;
        }

        if (rapidFireTimer < 0)
        {
            DeactivateRapidFire();
        }

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
        // Debug.Log("Player is shooting");
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
        // Debug.Log("Player is taking damage");
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

    public void AddNuke()
    {
        nukeCounter++;

        OnNukeUpdate?.Invoke(nukeCounter);
    }

    public void UseNuke()
    {
        if(nukeCounter > 0)
        {
            nukeCounter--;
            ParticleSystem nukeInstance = Instantiate(nukeParticles, transform.position, Quaternion.identity);
            nukeInstance.Play();
            GameManager.GetInstance().NotifyNukeUse();
            OnNukeUpdate?.Invoke(nukeCounter);
        }
    }

    public void ActivateRapidFire(float fireRateMultiplier, float duration)
    {
        if (rapidFireTimer > 0)
        {
            DeactivateRapidFire();
            playerAnimator.Play("RapidFireActivation", -1, 0f);
        }

        rapidFireTimer = duration;

        this.fireRateMultiplier = fireRateMultiplier;
        weapon.SetRPS (weapon.RPS * fireRateMultiplier);

        playerAnimator.SetTrigger("rapidFireActivated");
        playerAnimator.SetBool("rapidFireActive", true);
    }

    void DeactivateRapidFire()
    {

        rapidFireTimer = 0;
        // Return fire rate to normal
        weapon.SetRPS (weapon.RPS / this.fireRateMultiplier);
        this.fireRateMultiplier = 1f;
        playerAnimator.ResetTrigger("rapidFireActivated");
        playerAnimator.SetBool("rapidFireActive", false);
    }
}
