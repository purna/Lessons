using UnityEngine;

public class SimpleCarController2D : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of the cube's forward movement.
    public float rotationSpeed = 90.0f; // Speed of cube rotation in degrees per second.
    public float brakingDeceleration = 2.0f; // Rate of deceleration when braking.
    public float gravityStrength = 9.81f; // Strength of gravity.

    private Rigidbody rb;
    private float moveDirection;
    private float rotationInput;
    private float brakeInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable Unity's built-in gravity.
    }

    private void Update()
    {
        // Read input for movement, rotation, and braking.
        moveDirection = Input.GetKey(KeyCode.UpArrow) ? 1.0f : (Input.GetKey(KeyCode.DownArrow) ? -1.0f : 0.0f);
        rotationInput = Input.GetKey(KeyCode.LeftArrow) ? -1.0f : (Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f);
        brakeInput = Input.GetKey(KeyCode.Space) ? 1.0f : 0.0f;

        // Apply forward movement on the X-axis.
        rb.velocity = transform.right * moveDirection * moveSpeed;

        // Apply rotation around the Y-axis.
        float rotation = rotationInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        // Apply gradual deceleration when braking.
        if (brakeInput > 0f)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, brakingDeceleration * Time.deltaTime);
        }

        // Apply gravity to keep the cube on the ground.
        Vector3 gravity = -Vector3.up * gravityStrength;
        rb.AddForce(gravity, ForceMode.Acceleration);
    }
}
