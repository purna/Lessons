using UnityEngine;
using System.Collections;

public class ActiveObjects : MonoBehaviour
{
    public GameObject myObject;

    private bool IsActive = true;

    void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {

        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            myObject.SetActive(!myObject.activeSelf); // Toggle the object's active state
        }
        */

        if (Input.GetKeyDown(KeyCode.Space))
        {

            if (IsActive == false)
            {
                myObject.SetActive(true);
                IsActive = true;
            }
            else
            {
                myObject.SetActive(false);
                IsActive = false;
            }
        }
        
    }
}