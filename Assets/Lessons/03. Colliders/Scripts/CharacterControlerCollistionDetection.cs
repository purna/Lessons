using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CharacterControlerCollistionDetection : MonoBehaviour
{

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the collision was with a wall.
        if (hit.gameObject.CompareTag("Player"))
        {
            

        }

    }
}
