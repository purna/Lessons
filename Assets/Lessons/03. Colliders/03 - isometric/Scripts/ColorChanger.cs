using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Material newMaterial;
    public Material thisMaterial;

    public CharacterController characterController;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the collision was with a wall.
        if (hit.gameObject.tag == "Player")
        {
            // Do something when the player collides with a wall.
            Debug.Log("ouch");

            changeColor();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ouch");

        // Get the renderer of the object that collided with us.
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();

        // Set the material of the object that collided with us.
        renderer.material = newMaterial;


        // Get the child objects of the object that caused the collision.
        Transform[] colliderChildObjects = collision.collider.gameObject.GetComponentsInChildren<Transform>();

        // Set the materials of the child objects.
        foreach (Transform colliderChildObject in colliderChildObjects)
        {
            Renderer colliderChildRenderer = colliderChildObject.GetComponent<Renderer>();
            colliderChildRenderer.material = newMaterial;
        }

        changeColor();
    }

        private void changeColor()
    {
        // Get the renderer of this object.
        Renderer thisRenderer = gameObject.GetComponent<Renderer>();

        // Set the material of this object.
        thisRenderer.material = thisMaterial;

        // Get the child objects of the object that collided with us.
        Transform[] childObjects = gameObject.GetComponentsInChildren<Transform>();

        // Set the materials of the child objects.
        foreach (Transform childObject in childObjects)
        {
            Renderer childRenderer = childObject.GetComponent<Renderer>();
            childRenderer.material = newMaterial;
        }

       
    }
}
