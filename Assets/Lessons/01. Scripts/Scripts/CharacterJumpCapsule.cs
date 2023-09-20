using UnityEngine;
using UnityEngine.UIElements;


public class CharacterJumpCapsule : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 boxSize;
    public float maxDistance = 1f;
    public float jumpforce = 10f;

    public CapsuleCollider characterCollider;

    public LayerMask groundLayer;

    // adjust this to control how high above the ground the object has to be before it's considered grounded
    public float groundColliderHeight = 0.025f;


    bool CapsuleGroundCheck()
    { 

        RaycastHit hit;

        // transform.froward = Z axis
        // transform.right = X axis
        // transfrom.up = Y axis
       
        Vector3 p1 = transform.position + characterCollider.center + Vector3.up * -characterCollider.height * 0.5F;
        Vector3 p2 = p1 + Vector3.up * characterCollider.height;
        float distanceToObstacle = 0;

        // Cast shape 10 meters forward to see if it is about to hit anything.
        if (Physics.CapsuleCast(
            p1,
            p2,
            characterCollider.radius,
            transform.forward,
            out hit,
            maxDistance))
        {
            distanceToObstacle = hit.distance;
            Debug.Log("Yeah baby" + distanceToObstacle);
            return true;
        } else
        {
            return false;
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


    // Update is called once per frame
    void Update()
    {

        bool BoxGround = CapsuleGroundCheck();

        if (BoxGround == true)
        {
            Debug.Log("Grounded : True");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
            }
        }


    }

}