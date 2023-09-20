using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    States state;
    Rigidbody rb;
    bool grounded;
    // Start is called before the first frame update
    void Start()
    {
        state = States.Idle;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        DoLogic();

    }

    void FixedUpdate()
    {
        grounded = false;
    }


    void DoLogic()
    {
        if (state == States.Idle)
        {
            PlayerStanding();
        }

        if (state == States.Jump)
        {
            PlayerJumping();
        }

        if (state == States.Walk)
        {
            PlayerWalk();
        }
    }


    void PlayerStanding()
    {
        if (Input.GetKeyDown("j"))
        {
            // simulate jump
            state = States.Jump;
            rb.velocity = new Vector3(0, 10, 0);
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(0, 0.5f, 0, Space.Self);

        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(0, -0.5f, 0, Space.Self);
        }

        if (Input.GetKey("up"))
        {
            state = States.Walk;
        }
    }

    void PlayerJumping()
    {
        // player is jumping, check for hitting the ground
        if (grounded == true)
        {
            //player has landed on floor
            state = States.Idle;
        }
    }

    void PlayerWalk()
    {
        rb.AddForce(transform.forward * 5f);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, 5f);
        if (Input.GetKeyUp("up"))
        {
            state = States.Idle;
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Floor")
        {
            grounded = true;
            print("landed!");
        }
        if (col.gameObject.tag == "Deadly")
        {
            state = States.Dead;
            print("dead!");
            Invoke("Revive", 2);
        }
    }

    void Revive()
    {
        state = States.Idle;
        print("idle");
    }


}