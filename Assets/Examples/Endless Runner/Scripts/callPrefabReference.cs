
using UnityEngine;

public class callPrefabReference : MonoBehaviour
{
    // Reference to the prefab you want to instantiate.
    public GameObject objectToInstantiate;

    public void Shout(string p)
    {
       // Debug.Log(p);
    }


    public void InstantiateObject()
    {
        if (objectToInstantiate != null)
        {
            // Instantiate the GameObject at a specific position and rotation.
            Vector3 spawnPosition = new Vector3(0f, 0f, 0f); // Adjust the position as needed.
            Quaternion spawnRotation = Quaternion.identity; // No rotation.

            Instantiate(objectToInstantiate, spawnPosition, spawnRotation);
        }
        else
        {
            Debug.LogWarning("Object to instantiate is not assigned.");
        }
    }
}