using UnityEngine;
using System.Collections;

public class EnemyBase : MonoBehaviour
{
    public int enemyHealth;
    public Transform target;
    public float speed = 3f;
    public float rotateSpeed = 5f;

    
    public float minDistance = 3f;
    public float maxDistance = 6f;

    private float targetDistance;
    private Rigidbody rb;
    public GameObject bullet;
    public float spawnInterval = 3f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemyHealth = 3;
        rb = GetComponent<Rigidbody>();

        targetDistance = Random.Range(minDistance, maxDistance);

        if (target == null)
        {
            GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
            if (playerObj != null)
                target = playerObj.transform;
        }
        StartCoroutine(SpawnRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealth == 0)
        {
            Destroy(gameObject);
        }
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
    }
    void FixedUpdate()
    {
        if (target != null)
        {
           
            Vector3 directionToPlayer = target.position - transform.position;
            directionToPlayer.y = 0f;
            directionToPlayer.Normalize();

            float currentDistance = Vector3.Distance(new Vector3(transform.position.x, 0, transform.position.z),
                                                    new Vector3(target.position.x, 0, target.position.z));

            
            if (directionToPlayer != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.fixedDeltaTime);
            }

            
            if (currentDistance > targetDistance + 0.2f)
            {
                // Too far away, move closer
                rb.linearVelocity = directionToPlayer * speed;
            }
            else if (currentDistance < targetDistance - 0.2f)
            {
                // Too close, back away
                rb.linearVelocity = -directionToPlayer * speed;
            }
            else
            {
                // Within the sweet spot, stop moving
                rb.linearVelocity = Vector3.zero;
            }
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }

    IEnumerator SpawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Instantiate(bullet, transform.position, transform.rotation);
        }
    }
}
