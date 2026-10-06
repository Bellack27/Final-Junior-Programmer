using UnityEngine;

public class EnemyBullet : BulletBase // INHERITANCE
{
    public GameObject targetObject;
    public GameObject ignoreTarget;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        base.Start();
        m_Rigidbody = GetComponent<Rigidbody>();  // POLYMORPHISM
        if (targetObject != null)
        {
            transform.LookAt(targetObject.transform);
        }

        if (ignoreTarget != null)
        {
            Collider myCollider = GetComponent<Collider>();
            Collider targetCollider = ignoreTarget.GetComponent<Collider>();

            if (myCollider != null && targetCollider != null)
            {
                // Tell Unity to ignore collisions between these two specific colliders
                Physics.IgnoreCollision(myCollider, targetCollider, true);
            }
        }
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        base.Start();
        BulletMove(); // INHERITANCE
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
