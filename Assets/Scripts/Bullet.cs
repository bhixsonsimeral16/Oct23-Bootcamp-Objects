using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;

    string targetTag;

    public void SetBullet(float _damage, string _targetTag, float _speed = 10f)
    {
        this.damage = _damage;
        this.targetTag = _targetTag;
        this.speed = _speed;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {
        if(damageable != null)
        {
            damageable.TakeDamage(damage);
            Debug.Log("Damaged something");
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != targetTag)
        {
            return;
        }
        
        Debug.Log($"Bullet collided with {collision.gameObject.name}");
        if(collision.gameObject.GetComponent<IDamageable>() != null)
        {
            Damage(collision.gameObject.GetComponent<IDamageable>());
        }
    }
}
