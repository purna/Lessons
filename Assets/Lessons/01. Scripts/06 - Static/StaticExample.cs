using System.Diagnostics;
using UnityEngine;

public class StaticExample : MonoBehaviour
{
    // Static variable shared among all instances of the script.
    public static int numberOfInstances = 0;

    // Instance-specific variable.
    public string instanceName;

    private void Start()
    {
        // Increment the static variable for each new instance.
        numberOfInstances++;

        // Assign a unique name to each instance.
        instanceName = "Instance " + numberOfInstances;

        // Log the instance name and the current value of the static variable.
        UnityEngine.Debug.Log("Created " + instanceName);
        UnityEngine.Debug.Log("Total Instances: " + numberOfInstances);
    }

    private void Update()
    {
        // Check for user input to demonstrate the static method.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Call the static method from any instance.
            StaticMethod();
        }
    }

    // Static method that can be called without an instance.
    public static void StaticMethod()
    {
        UnityEngine.Debug.Log("Static method called");
    }
}

