using UnityEngine;

public class PrefabReference : MonoBehaviour
{
    // Inside a script that handles collisions with obstacles.
    public callPrefabReference preRef; // Reference to the ScoreManager script.

    void Start()
    {
      
            // Remove a point from the score when an obstacle is hit.
            //scoreManager.RemoveScore(1);
            preRef.Shout("hi");

     
    }
}