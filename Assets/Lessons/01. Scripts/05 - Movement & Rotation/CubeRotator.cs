using UnityEngine;

public class CubeRotator : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Rotation speed in degrees per second.

    private void Update()
    {
        float rotationInput = Input.GetKey(KeyCode.LeftArrow) ? -1.0f : (Input.GetKey(KeyCode.RightArrow) ? 1.0f : 0.0f);

        // Rotate the cube around the Y-axis based on input.
        transform.Rotate(Vector3.up * rotationInput * rotationSpeed * Time.deltaTime);
    }
}
