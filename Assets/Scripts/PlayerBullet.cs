using UnityEngine;

public class PlayerBullet : BulletBase // INHERITANCE
{
    protected virtual void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();  // POLYMORPHISM
    }

    protected virtual void Update()
    {
        BulletMove(); // INHERITANCE
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (collision.gameObject.TryGetComponent(out EnemyBase enemy))
            {
                
                enemy.enemyHealth -= 1;

                Debug.Log($"Hit the Bad guy! Reduced health to: {enemy.enemyHealth}");
            }
            Destroy(gameObject);
        }
    }
}
