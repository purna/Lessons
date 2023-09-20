using UnityEngine;

public class CharacterControllerColliderHit : MonoBehaviour
{
    bool hasCollided = false;

    public Color newColor;

 

        private void OnControllerColliderHit(UnityEngine.ControllerColliderHit hit)
    {
        Debug.Log("ouch - OnControllerColliderHit " + hit.gameObject.name);



        // Check if the collision was with a wall.
        if (hit.gameObject.CompareTag("Box"))
        {

            // Get the renderer of the object that triggered us.
            //Renderer renderer = other.gameObject.GetComponent<Renderer>();

            Renderer renderer = hit.gameObject.GetComponent<Renderer>();

            // Set the color of the object that triggered us.
            renderer.material.color = newColor;


            // Check if the collision has already been processed.
            if (!hasCollided)
            {


                // Set the flag to true to indicate that the collision has been processed.
                hasCollided = true;
            }

        }

    }
}
