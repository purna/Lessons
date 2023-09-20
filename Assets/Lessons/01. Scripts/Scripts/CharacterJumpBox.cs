using UnityEngine;
using UnityEngine.UIElements;


public class CharacterJumpBox : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 boxSize;
    public float maxDistance = 1f;
    public float jumpforce = 10f;

    //public CapsuleCollider characterCollider;
    public BoxCollider characterCollider;

    public LayerMask groundLayer;

    // adjust this to control how high above the ground the object has to be before it's considered grounded
    public float groundColliderHeight = 0.025f;


    bool BoxGroundCheck()
    {
        // transform.froward = Z axis
        // transform.right = X axis
        // transfrom.up = Y axis

        //RaycastHit hit;

        //Vector3 boxCenter = characterCollider.bounds.center;
        //Vector3 halfExtents = characterCollider.bounds.extents;
        // modify the height of the box so that origin of the box cast isn't intersecting with the ground
        //halfExtents.y = groundColliderHeight;
        //Physics.BoxCast(boxCenter, halfExtents, Vector3.down, transform.rotation, maxDistance, layerMask);
        float distanceToObstacle = 0;

        if (
           Physics.BoxCast(
               transform.position,
               transform.lossyScale * 0.5f,
               transform.forward,
               Quaternion.identity,
               maxDistance
               
           ))
        {
            //distanceToObstacle = hit.distance;
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

        bool BoxGround = BoxGroundCheck();

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