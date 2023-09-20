using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkPassing : MonoBehaviour
{
    float lineDistance = 40;


    // Update is called once per frame
    void FixedUpdate()
    {
        DetectHit(transform.position, lineDistance, transform.forward);
    }

    RaycastHit DetectHit(Vector3 startPos, float lineDistance, Vector3 direction)
    {
        // init ray to save the start and direction values
        Ray ray = new Ray(startPos, direction);

        // variable to hold the detection info
        RaycastHit hit;

        // the end Pos which defaults  to the startPos + distance
        Vector3 endPos = startPos + (lineDistance * direction);

        if (Physics.Raycast(ray, out hit, lineDistance))
        {
            Debug.Log("There is something in front of the object");
            Debug.DrawRay(startPos, endPos, Color.red, 0.1f, false);
            endPos = hit.point;
        }

        //Debug.DrawRay(startPos, endPos, Color.green, 0.1f, false);
        return hit;

    }


    // Frame update example: Draws a 10 meter long green line from the position for 1 frame.
    /*
    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * lineDistance;
        Debug.DrawRay(transform.position, forward, Color.cyan);
    }
    */

    // Event callback example: Debug-draw all contact points and normals for 2 seconds.
    /*
    void OnCollisionEnter(Collision collision)
    {
        Debug.DrawRay(collision.contacts[0].point, collision.contacts[0].normal, Color.cyan, 2, false);
    }
    */
}