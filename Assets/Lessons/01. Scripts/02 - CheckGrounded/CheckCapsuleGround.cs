using UnityEngine;

public class CheckCapsuleGround : MonoBehaviour
{
    public LayerMask groundLayer; // The layer mask for the ground objects.

    // Define a float variable for the capsule cast's radius.
    public float capsuleRadius = 0.1f;

    // Define a float variable for the capsule cast's height.
    public float capsuleHeight = 0.2f; // Adjust this height to match your capsule's size.


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
        Vector3 capsuleStart = transform.position + Vector3.up * capsuleHeight * 0.5f;
        Vector3 capsuleEnd = transform.position - Vector3.up * capsuleHeight * 0.5f;

        //RaycastHit hit;

        

        // Create a CapsuleCast to check if the object is on the ground.
        //bool isOnGround = Physics.CapsuleCast(capsuleStart, capsuleEnd, capsuleRadius, Vector3.down, out hit, raycastLength, groundLayer);


        bool isOnGround = Physics.CapsuleCast(capsuleStart, capsuleEnd, capsuleRadius, Vector3.down, capsuleHeight * 0.5f + 0.1f, groundLayer);


        if (isOnGround)
        {
            if (!hasLogged)
            {
                Debug.Log("Capsule is on the ground.");
                hasLogged = true;
            }
            else
            {

            }

            // Get the Renderer component of the GameObject.
            objectRenderer = GetComponent<Renderer>();
            // Change the color of the object's material.
            objectRenderer.material.color = newColor;
        }
    }

    /*
    bool IsGrounded()
    {
        Vector3 point1 = transform.position + Vector3.up * capsuleRadius;
        Vector3 point2 = transform.position - Vector3.up * capsuleRadius;

        // Use Physics.CheckCapsule to check if the capsule is grounded on the specified groundLayer.
        return Physics.CheckCapsule(point1, point2, capsuleRadius, groundLayer);
    }
    */
    



}