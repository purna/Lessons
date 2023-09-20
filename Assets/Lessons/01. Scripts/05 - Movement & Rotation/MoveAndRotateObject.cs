using UnityEngine;

public class SimpleCarController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of the cube's forward movement.
    public float rotationSpeed = 90.0f; // Speed of cube rotation in degrees per second.
    public float brakeForce = 10.0f; // Force applied to brake the cube.

    private Rigidbody rb;
    private Vector3 moveDirection = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Read input for movement and rotation.
        float forwardInput = Input.GetKey(KeyCode.UpArrow) ? 1.0f : 0.0f;
        float rotationInput = Input.GetKey(KeyCode.LeftArrow) ? -1.0f : (Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f);
        float brakeInput = Input.GetKey(KeyCode.DownArrow) ? 1.0f : 0.0f;

        // Apply forward movement.
        moveDirection = transform.forward * forwardInput * moveSpeed;

        // Apply rotation.
        Vector3 rotation = Vector3.up * rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);

        // Apply braking force to slow down.
        if (brakeInput > 0f)
        {
            rb.AddForce(-rb.velocity.normalized * brakeForce, ForceMode.Acceleration);
        }
    }

    private void FixedUpdate()
    {
        // Apply the forward movement force in FixedUpdate for physics interactions.
        rb.velocity = moveDirection;
    }
}
