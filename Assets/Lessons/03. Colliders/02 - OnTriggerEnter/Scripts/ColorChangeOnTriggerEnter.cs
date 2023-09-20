using UnityEngine;

public class ColorChangeOnTriggerEnter : MonoBehaviour
{
    public Color newColor;

    private void OnTriggerEnter(Collider other)
    {


        // Get the renderer of the object that triggered us.
        //Renderer renderer = other.gameObject.GetComponent<Renderer>();

        Renderer renderer = gameObject.GetComponent<Renderer>();

        // Set the color of the object that triggered us.
        renderer.material.color = newColor;
    }
}