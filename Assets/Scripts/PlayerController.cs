using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject myPrefab;
    public float moveSpeed;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    public float rotationSpeed = 15f;
    public Camera mainCamera;
    public int playerHealth;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
    

        RotateTowardsMouse();
        MovePlayer();

        if (Input.GetMouseButtonDown(0)) // 0 represents the left mouse button
        {
            shoot();

        }

        if (playerHealth == 0)
        {
            Destroy(gameObject);
        }


    }
    void RotateTowardsMouse() // ABSTRACTION
    {
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, transform.position.y, 0));
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 lookPoint = ray.GetPoint(distance);
            Vector3 direction = (lookPoint - transform.position);
            direction.y = 0;

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
    void MovePlayer() // ABSTRACTION
    {
        float h = Input.GetAxisRaw("Horizontal"); // A/D
        float v = Input.GetAxisRaw("Vertical");   // W/S

        Vector3 moveDirection = (Vector3.forward * v + Vector3.right * h).normalized;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }

    void shoot() // ABSTRACTION
    {
        
        float offsetDistance = 1.5f;
        Vector3 spawnPosition = transform.position + (transform.forward * offsetDistance);
        Instantiate(myPrefab, spawnPosition, transform.rotation);


    }

}
