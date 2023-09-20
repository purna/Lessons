using UnityEngine;

public class QuaternionExample : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Rotation speed in degrees per second.

    private Quaternion startRotation;
    private Quaternion targetRotation;
    private float t = 0.0f; // Interpolation parameter.

    private void Start()
    {
        // Store the initial rotation of the object.
        startRotation = transform.rotation;

        // Define a target rotation (90 degrees around the Y-axis).
        targetRotation = Quaternion.Euler(0, 90, 0);
    }

    private void Update()
    {
        // Interpolate between startRotation and targetRotation using Slerp.
        t += Time.deltaTime * rotationSpeed;
        transform.rotation = Quaternion.Slerp(startRotation, targetRotation, t);

        // Reset the interpolation parameter when it reaches 1.
        if (t >= 1.0f)
        {
            t = 0.0f;
            // Swap the start and target rotations for continuous rotation.
            Quaternion temp = startRotation;
            startRotation = targetRotation;
            targetRotation = temp;
        }
    }
}
