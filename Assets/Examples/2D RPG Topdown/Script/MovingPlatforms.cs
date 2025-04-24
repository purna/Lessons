using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.5f;
    public int direction = 1;    
    private bool isMoving = false; // Flag to check if the platform should be moving
    public bool loop = true; // Option to loop the platform's movement

    private void OnDrawGizmos(){
        // just for 
        
        if (platform!=null && startPoint!=null && endPoint!=null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);

        }
    }

    // Update is called once per frame
    void Update()
    {
    
    // Only move the platform if it's set to move
        if (isMoving)
        {
            Vector2 target = currentMovementTarget();
            platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

            float distance = (target - (Vector2)platform.position).magnitude;
             // Determine the next point based on the looping setting
            if (loop)
            {
                if (distance <= 0.1f)
                {
                    direction *= -1;
                }
            }
        }

        
    }

    // Public method to allow external scripts to start or stop the platform
    public void SetIsMoving(bool moving)
    {
        isMoving = moving;
    }


    Vector2 currentMovementTarget()
    {
        if (direction == 1){
            return startPoint.position; 
        } else{
             return endPoint.position;
        }
    }

    // Ensure player becomes a child of the platform on collision
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Start moving the platform when the player jumps onto it
            isMoving = true;
            col.gameObject.transform.SetParent(platform.transform, true);
        }
    }

    // Ensure player stops following the platform when exiting collision
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // Stop the platform when the player leaves it
            isMoving = false;
            if (col.gameObject.transform.parent == platform.transform)
            {
                col.gameObject.transform.SetParent(null, true);
            }
        }
    }

   
}
