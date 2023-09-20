using UnityEngine;

public class CheckCubeGround : MonoBehaviour
{
    public LayerMask groundLayer; // The layer mask for the ground objects.

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
        // Create a BoxCast starting from the center of the object and moving downwards.
        RaycastHit hit;

        bool isOnGround = Physics.BoxCast(transform.position, Vector3.one * 0.5f, Vector3.down, out hit, Quaternion.identity, raycastLength, groundLayer);

        //bool isOnGround = Physics.BoxCast(transform.position, Vector3.one * 0.5f, Vector3.down, out hit, Quaternion.identity, raycastLength, groundLayer);

         
        if (isOnGround)
        {
            if (!hasLogged)
            {
                Debug.Log("Cube is on the ground.");
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

        //Vector3 boxSize = new Vector3(0.1f, 0.1f, 0.1f); // Adjust these values to match your box's size.

        // Get the size of the current item's collider.
        Vector3 boxSize = objectRenderer.GetComponent<Collider>().bounds.size;


        // Calculate the center of the box at the groundCheck position.
        Vector3 boxCenter = transform.position + Vector3.down * (boxSize.y * 0.5f);

        // Use Physics.CheckBox to check if the box is grounded on the specified groundLayer.
        return Physics.CheckBox(boxCenter, boxSize* 0.5f, Quaternion.identity, groundLayer);

    }
    */



}