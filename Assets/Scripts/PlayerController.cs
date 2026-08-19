using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 6.0f;
    public float gravity = 20.0f;
    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        // Only allow input processing if the player is touching the ground
        if (controller.isGrounded)
        {
            float moveX = Input.GetAxis("Horizontal");
            float moveZ = Input.GetAxis("Vertical");

            moveDirection = new Vector3(moveX, 0.0f, moveZ);
            moveDirection = transform.TransformDirection(moveDirection); // Move relative to player orientation
            moveDirection *= speed;
        }

        // Apply constant gravity over time
        moveDirection.y -= gravity * Time.deltaTime;

        // Execute the movement command
        controller.Move(moveDirection * Time.deltaTime);
    }
}
