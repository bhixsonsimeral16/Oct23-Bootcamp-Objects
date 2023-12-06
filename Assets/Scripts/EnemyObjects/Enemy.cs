using UnityEngine;

public class Enemy : PlayableObjects
{
    string enemyName;
    EnemyType enemyType;
    protected Transform target;
    [SerializeField] protected float speed;


    protected virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if(target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(speed);
        }
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        Debug.Log("Enemy is moving");
    }

    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    public override void Shoot()
    {
        Debug.Log("Enemy is shooting");
    }

    public override void Attack(float interval)
    {
        Debug.Log("Enemy is attacking");
    }

    public override void Die()
    {
        Debug.Log($"Enemy is dead");
        GameManager.GetInstance().enemyCount--;
        Destroy(gameObject);
    }

    public virtual void BattleCry()
    {
        Debug.Log($"Enemy is shouting");
    }

    public override void TakeDamage(float damage)
    {
        throw new System.NotImplementedException();
    }
}
