using UnityEngine;

public class Enemy
{
    string name;
    float speed;
    public Health health = new Health();
    public Weapon weapon;
    EnemyType enemyType;

    public void Move(Transform target)
    {
        // Move towards target
        Debug.Log("Enemy is moving");
    }

    public void Shoot(Vector3 direction, float bulletSpeed)
    {
        Debug.Log("Enemy is shooting");
    }

    public void Attack(float interval)
    {
        Debug.Log("Enemy is attacking");
    }

    public void Die(string message)
    {
        Debug.Log($"Enemy is dead: {message}");
    }
}
