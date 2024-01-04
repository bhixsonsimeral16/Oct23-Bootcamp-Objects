using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] float attackRange = 2f;
    [SerializeField] float attackInterval = 0.2f;
    float timer = 0f;
    float setSpeed = 0f;

    public void SetMeleeEnemy(float _attackRange, float _attackInterval)
    {
        attackRange = _attackRange;
        attackInterval = _attackInterval;
    }

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
        setSpeed = speed;

        weapon = new Weapon("Melee", 1f, 0f);
    }

    protected override void Update()
    {
        base.Update();

        if (target == null)
        {
            return;
        }

        else if (Vector2.Distance(transform.position, target.position) <= attackRange)
        {
            speed = 0f;
            Attack(attackInterval);
        }
        else
        {
            speed = setSpeed;
        }
    }

    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0f;
            target.GetComponent<IDamageable>().TakeDamage(weapon.GetDamage());
            // Debug.Log("Enemy is attacking");
        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void BattleCry()
    {
        Debug.Log("Taste my blade!");
    }
}
