
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{

    public Rigidbody2D playerBox; // allows me to manipulate rigidbox globally -> set in editor

    // Use this for initialization
    void Start()
    {
        GameObject startingPlat = GameObject.Find("Capsule");
        startingPlat.layer = LayerMask.NameToLayer("Ground");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) == true) // if spacebar or up
        {
            print("key pressed!");
            bool grounded = (Physics.Raycast((new Vector2(playerBox.transform.position.x, playerBox.transform.position.y + 1f)), Vector3.down, 2f, 1 << LayerMask.NameToLayer("Ground"))); // raycast down to look for ground is not detecting ground? only works if allowing jump when grounded = false; // return "Ground" layer as layer
            Debug.DrawRay((new Vector3(playerBox.transform.position.x, playerBox.transform.position.y + 1f, playerBox.transform.position.z)), Vector3.down, Color.green, 5);

            if (grounded == true)
            {
                print("grounded!");
                jump();
            }
            else if (grounded == false)
            {
                print("Can't Jump - Not Grounded");
            }
        }
    }


    void jump()
    {
        int jumpSpeed = 500;
        playerBox.AddForce(new Vector2(0, jumpSpeed));
        print("jump!");
    }
}