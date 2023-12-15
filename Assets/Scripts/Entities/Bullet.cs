using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float damage;
    [SerializeField] GameObject outlineCircle;

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
        ChangeOutlineColor();
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {
        Debug.Log("Attempting to damage something");
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

    void ChangeOutlineColor()
    {
        // Ocilate the color of the outline circle in a rainbow pattern
        var color = Color.HSVToRGB(Mathf.PingPong(Time.time, 1), 1, 1);
        outlineCircle.GetComponent<SpriteRenderer>().color = color;
    }
}
