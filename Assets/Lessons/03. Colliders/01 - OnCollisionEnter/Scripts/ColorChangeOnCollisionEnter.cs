using UnityEngine;

public class ColorChangeOnCollisionEnter : MonoBehaviour
{
    public Color newColor;

    private void OnCollisionEnter(Collision collision)
    {
        // Get the renderer of the object that collided with us.
        //Renderer renderer = collision.gameObject.GetComponent<Renderer>();

        // Get the cube reference
        Renderer renderer = gameObject.GetComponent<Renderer>();

        // Set the color of the object that collided with us.
        renderer.material.color = newColor;
    }
}