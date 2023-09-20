using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast2dtest : MonoBehaviour
{
    RaycastHit2D hit;

    void FixedUpdate()
    {

        hit = Physics2D.Raycast(transform.position, Vector2.left);

        Debug.Log(hit.collider);

    }
}