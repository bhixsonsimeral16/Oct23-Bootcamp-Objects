using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperEnemy : Enemy
{
    [SerializeField] float attackRange = 15f;
    [SerializeField] float accuracy = 1f; // 0 - 1f, 0.9f is 90% accuracy
    [SerializeField] Bullet bulletPrefab;

    float setSpeed = 0f;
    string targetTag = "Player";

    public void SetShooterEnemy(float _attackRange, float _accuracy = 1f)
    {
        attackRange = _attackRange;
        accuracy = _accuracy;
        weapon.accuracy = accuracy;
    }

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
        setSpeed = speed;
        weapon = new Weapon("Sniper", 6f, 15f, 0.25f, accuracy);
    }

    protected override void Update()
    {
        // TODO: Sniper should move back to max range after shooting
        base.Update();

        if (target == null)
        {
            return;
        }

        else if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            speed = 0f;
            Attack();
        }
        else
        {
            speed = setSpeed;
        }
    }

    public override void Attack(float interval = 0f)
    {
        weapon.Shoot(bulletPrefab, this, targetTag, accuracy);
        // Debug.Log("Enemy is attacking");
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }
    public override void BattleCry()
    {
        Debug.Log("They never saw me coming!");
    }
}
