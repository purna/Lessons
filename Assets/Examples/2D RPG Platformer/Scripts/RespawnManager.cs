using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform[] respawnPoints; // Assign your respawn waypoints to this array
    public GameObject playerPrefab; // Assign the player prefab in the Inspector
    public float respawnDelay = 2.0f; // The delay before respawning the player

    private Transform lastWaypoint; // Store the last waypoint where the player respawned
    private bool hasPassedWaypoint = false;


    private  Vector3 respawnPosition;
    public Transform spawnPoint;



    private void Start()
    {
        // Set the respawn position to the spawn point
        respawnPosition = spawnPoint.position;
        // set the first waypoint
        lastWaypoint = spawnPoint;

        spawnPlayer();
    }

    public Vector3 OnPlayerPassWaypoint(bool hasPassedWaypoint)
    {
        if (hasPassedWaypoint)
        {
            // Handle respawning logic here based on the hasPassedWaypoint value.
            Debug.Log("Respawn Player - has passed waypoint");

            respawnPosition = lastWaypoint.position;


        }
        return respawnPosition;
    }
    public void spawnPlayer()
    {
        GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");
        if (existingPlayer == null)
        {
            GameObject newPlayer = Instantiate(playerPrefab, respawnPosition, Quaternion.identity);

        }
    }

    public void RespawnPlayer()
    {


        if (lastWaypoint != null)
        {

            // Destroy the previous player if it exists
            GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");

            if (existingPlayer != null)
            {
                existingPlayer.SetActive(true);
                existingPlayer.transform.position = new Vector3(lastWaypoint.position.x, lastWaypoint.position.y, 0);
            }


            //GameObject deathPlayer = GameObjec

            // Get the position of the last waypoint
            respawnPosition = lastWaypoint.position;

            // Instantiate a new player prefab at the last waypoint
            //GameObject newPlayer = Instantiate(playerPrefab, respawnPosition, Quaternion.identity);

            // Store the last waypoint for future respawns
            lastWaypoint = respawnPoints[Random.Range(0, respawnPoints.Length)];

            //spawnPlayer();

            // You may need to reset any player-related components, health, or status here.
            // For example, if the player has a health component, reset it.

            // You can set up any additional logic for respawning here.
            // For example, resetting the player's health or any other game-specific values.

            // After a delay, you can enable player control, if necessary.
            // newPlayer.GetComponent<PlayerController>().enabled = true;

            // You can enable input or other components as needed.
            // newPlayer.GetComponent<PlayerInput>().enabled = true;

            // Other setup and logic may be required depending on your game.
           
        }
    }
}
