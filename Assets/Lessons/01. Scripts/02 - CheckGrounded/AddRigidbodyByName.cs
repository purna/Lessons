using UnityEngine;

public class AddRigidbodyByName : MonoBehaviour
{
    public string objectNameToFind = "ObjectName"; // Replace with the name of the object you want to add a Rigidbody to.
    public KeyCode addRigidbodyKey = KeyCode.Space; // Define the key to trigger adding the Rigidbody.

    private void Update()
    {
        if (Input.GetKeyDown(addRigidbodyKey))
        {
            // Find the object by name.
            GameObject objectToAddRigidbody = GameObject.Find(objectNameToFind);

            if (objectToAddRigidbody != null)
            {
                // Check if the object already has a Rigidbody.
                Rigidbody existingRigidbody = objectToAddRigidbody.GetComponent<Rigidbody>();

                if (existingRigidbody == null)
                {
                    // Add a Rigidbody component to the object.
                    Rigidbody newRigidbody = objectToAddRigidbody.AddComponent<Rigidbody>();
                    Debug.Log("Added Rigidbody to " + objectNameToFind);
                }
                else
                {
                    Debug.LogWarning(objectNameToFind + " already has a Rigidbody.");
                }
            }
            else
            {
                Debug.LogError("Object with name " + objectNameToFind + " not found.");
            }
        }
    }
}
