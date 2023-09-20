using UnityEngine;

public class MoveForwardAndBackward : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of movement on the X-axis.

    private void Update()
    {
        float moveInput = Input.GetAxis("Vertical"); // Get input from both up and down arrow keys.

        // Calculate the movement vector.
        Vector3 moveDirection = new Vector3(moveInput, 0.0f, 0.0f);

        // Translate the object's position to move it.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
