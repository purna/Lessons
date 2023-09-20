using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Speed of forward movement on the X-axis.

    private void Update()
    {
        float moveInput = Input.GetKey(KeyCode.UpArrow) ? 1.0f : 0.0f;

        // Calculate the movement vector.
        Vector3 moveDirection = new Vector3(moveInput, 0.0f, 0.0f);

        // Translate the object's position to move it forward.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
