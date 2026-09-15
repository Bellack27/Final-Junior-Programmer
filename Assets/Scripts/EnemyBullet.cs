using UnityEngine;

public class EnemyBullet : BulletBase
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (collision.gameObject.TryGetComponent(out PlayerController player))
            {
                // 2. Modify the player's variable (Replace 'health' and value as needed)
                player.playerHealth -= 1;

                Debug.Log($"Hit the Player! Reduced health to: {player.playerHealth}");
            }
            Destroy(gameObject);
        }
    }
}
