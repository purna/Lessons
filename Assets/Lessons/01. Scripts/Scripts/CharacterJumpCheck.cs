using UnityEngine;
using UnityEngine.UIElements;


public class CharacterJumpCheck : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 boxSize;
    public float maxDistance;
    public float jumpforce = 10f;


    public Transform groundCheck;
    public LayerMask groundLayer;
    public float groundCheckRadius;


    // adjust this to control how high above the ground the object has to be before it's considered grounded
    public float groundColliderHeight = 0.025f;




    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && IsGroundedBox())
        {
            Debug.Log("IsGroundedBox : True");

            Jump();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGroundedSphere())
        {
            Debug.Log("IsGroundedSphere : True");

            Jump();
        }



    }


    void Jump()
    {
        rb.AddForce(transform.up * jumpforce, ForceMode.Impulse);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position - transform.up * maxDistance, boxSize);
        /*
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(transform.position - transform.up * maxDistance, radius);
        */
    }


    bool IsGroundedSphere()
    {
        return Physics.CheckSphere(groundCheck.position, groundColliderHeight, groundLayer);
    }


    bool IsGroundedBox()
    {
        return Physics.CheckBox(groundCheck.position, groundCheck.transform.up, groundCheck.transform.rotation, groundLayer);
    }


}