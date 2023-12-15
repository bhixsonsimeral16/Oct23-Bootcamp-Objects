using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ExploderEnemy : Enemy
{
    [SerializeField] float attackRange = 0.1f;
    float setSpeed = 0f;

    public void SetExploderEnemy(float _attackRange)
    {
        attackRange = _attackRange;
    }

    protected override void Start()
    {
        base.Start();
        health = new Health(1, 0, 1);
        setSpeed = speed;
        weapon = new Weapon("Self-Destruct", 40f, 0f, 0f);
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
            Attack();
        }
        else
        {
            speed = setSpeed;
        }
    }

    public override void Attack(float interval = 0f)
    {
        target.GetComponent<IDamageable>().TakeDamage(weapon.GetDamage());
        Debug.Log("Enemy is attacking");
        // TODO: Trigger explosion animation?
        Die();
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public override void BattleCry()
    {
        Debug.Log("Watch out for my explosion!");
    }
}
