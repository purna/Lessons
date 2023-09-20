using UnityEngine;

public class Obstacles : MonoBehaviour
{
    // Inside a script that handles collisions with obstacles.
    public ScorePlayerManager scoreManager; // Reference to the ScoreManager script.
    private bool hasCollided = false; // Flag to track if the collision has occurred.


    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the collision was with a wall.
        if (hit.gameObject.CompareTag("Player"))
        {
             // Check if the collision has already been processed.
            if (!hasCollided)
            {
                Debug.Log("ouch - hit");
                // Remove a point from the score when an obstacle is hit.
                scoreManager.RemoveScore(1);
                //ScorePlayerManager.Instance.RemoveScore(1);

                // Set the flag to true to indicate that the collision has been processed.
                hasCollided = true;
            }

        }
 
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("ouch");
            // Remove a point from the score when an obstacle is hit.
            scoreManager.RemoveScore(1);
            //ScorePlayerManager.Instance.RemoveScore(1);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
    
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("ouch");
            // Remove a point from the score when an obstacle is hit.
            scoreManager.RemoveScore(1);
            //ScorePlayerManager.Instance.RemoveScore(1);

        }
    }
}
