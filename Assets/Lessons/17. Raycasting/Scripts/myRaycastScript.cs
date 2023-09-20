using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myRaycastScript : MonoBehaviour
{

    // Use this for initialization  
    void Start()
    {

    }



    //movement speed in units per second
    //private float movementSpeed = 5f;

    void Update()
    {
        //get the Input from Horizontal axis
        float horizontalInput = Input.GetAxis("Horizontal");
        //get the Input from Vertical axis
        float verticalInput = Input.GetAxis("Vertical");

        //update the position
        //transform.position = transform.position + new Vector3(horizontalInput * movementSpeed * Time.deltaTime, verticalInput * movementSpeed * Time.deltaTime, 0);

    
        float xDirection = Input.GetAxis("Mouse X");
        float yDirection = Input.GetAxis("Mouse Y");

        transform.position = transform.position + new Vector3(xDirection, yDirection, 0);

        //output to log the position change
        Debug.Log(transform.position);

        CheckIfRayCastHit();
    }


    void CheckIfRayCastHit()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.forward, out hit))
        {
            print(hit.collider.gameObject.name + "has been destroyed!");
            Destroy(hit.collider.gameObject);
        }
    }
}