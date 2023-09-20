using UnityEngine;

public class CheckSphereGround : MonoBehaviour
{
    public LayerMask groundLayer; // The layer mask for the ground objects.

    public float sphereRadius = 0.25f; // Radius of the sphere.
    public float raycastLength = 0.1f; // Length of the raycast from the object's center.


    // transform.froward = Z axis
    // transform.right = X axis
    // transfrom.up = Y axis

    private bool hasLogged = false;
    // Flag to track if the message has been logged.

    // You can add your ground behavior or logic here.
    public Color newColor = Color.red; // Define the new color you want to set.

    private Renderer objectRenderer;

    private void Update()
    {
        // Create a SphereCast to check if the object is on the ground.
        RaycastHit hit;
        bool isOnGround = Physics.SphereCast(transform.position, sphereRadius, Vector3.down, out hit, raycastLength, groundLayer);


        if (isOnGround)
        {
            if (!hasLogged)
            {
                Debug.Log("Sphere is on the ground.");
                hasLogged = true;
            }
            else
            {

            }
            // You can add your ground behavior or logic here.

            // Get the Renderer component of the GameObject.
            objectRenderer = GetComponent<Renderer>();
            // Change the color of the object's material.
            objectRenderer.material.color = newColor;
        }


        
    }

    /*
    bool IsGrounded()
    {
        return Physics.CheckSphere(transform.position, .1f, groundLayer);

    }
    */
}
