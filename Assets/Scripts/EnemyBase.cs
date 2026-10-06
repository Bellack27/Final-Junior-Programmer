using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public int enemyHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
