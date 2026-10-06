using UnityEngine;

public class PlayerBullet : BulletBase
{
    protected virtual void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    protected virtual void Update()
    {
        BulletMove();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            if (collision.gameObject.TryGetComponent(out EnemyBase enemy))
            {
                // 2. Modify the player's variable (Replace 'health' and value as needed)
                enemy.enemyHealth -= 1;

                Debug.Log($"Hit the Bad guy! Reduced health to: {enemy.enemyHealth}");
            }
            Destroy(gameObject);
        }
    }
}
