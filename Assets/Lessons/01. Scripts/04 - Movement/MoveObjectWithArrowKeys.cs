
using UnityEngine;

/*

public class MoveObjectWithArrowKeys : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of the object's movement.

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput);
        Vector3 moveAmount = moveDirection.normalized * moveSpeed * Time.deltaTime;

        // Move the object based on input.
        transform.Translate(moveAmount);
    }
}
*/


public class MoveObjectWithArrowKeys : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of the object's movement.
    public float brakeForce = 10.0f; // Force applied to brake the object.

    private Rigidbody rb;
    private Vector3 moveDirection;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0.0f, verticalInput).normalized;

        // Check for arrow key input to move the object.
        if (moveDirection.magnitude > 0)
        {
            Vector3 moveAmount = moveDirection * moveSpeed * Time.deltaTime;

            // Apply movement force.
            rb.AddForce(moveAmount, ForceMode.VelocityChange);
        }
        else
        {
            // Apply braking force to slow down when no arrow keys are pressed.
            rb.AddForce(-rb.velocity.normalized * brakeForce, ForceMode.Acceleration);
        }
    }
}

