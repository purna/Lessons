using UnityEngine;
using System.Collections;

public class ExampleBehaviourScript : MonoBehaviour
{
    public GameObject myObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            myObject.GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            myObject.GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            myObject.GetComponent<Renderer>().material.color = Color.blue;
        }
    }
}