using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject obstaclePrefab; // The obstacle prefab to spawn.
    public Transform player;           // Reference to the player's transform.
    public Transform finishLine;       // Reference to the finish line's transform.
    public float initialSpawnRange = 0.2f; // Initial spawn range (20% of the total distance).
    public float spawnRangeIncrement = 0.2f; // Increment in spawn range for each interval (20% of the total distance).
    public float playerProgress = 0f;  // Player's progress from 0 to 1.

    private List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start()
    {
        SpawnInitialObstacles();
    }

    private void Update()
    {
        // Calculate the player's progress as a value between 0 and 1.
        playerProgress = Mathf.Clamp01((player.position.x - transform.position.x) / (finishLine.position.x - transform.position.x));

        // Determine the current spawn range based on player progress.
        float minSpawnDistance = initialSpawnRange + playerProgress * spawnRangeIncrement;
        float maxSpawnDistance = minSpawnDistance + spawnRangeIncrement;

        // Spawn obstacles if the player has reached the next interval.
        if (playerProgress >= minSpawnDistance)
        {
            SpawnObstacle(minSpawnDistance, maxSpawnDistance);
        }
    }

    private void SpawnInitialObstacles()
    {
        // Spawn obstacles in the initial range.
        float minSpawnDistance = 0f;
        float maxSpawnDistance = initialSpawnRange;
        SpawnObstacle(minSpawnDistance, maxSpawnDistance);
    }

    private void SpawnObstacle(float minSpawnDistance, float maxSpawnDistance)
    {
        // Calculate a random spawn position within the specified range.
        float spawnXPosition = Random.Range(minSpawnDistance, maxSpawnDistance) * (finishLine.position.x - transform.position.x) + transform.position.x;
        Vector3 spawnPosition = new Vector3(spawnXPosition, transform.position.y, transform.position.z);

        // Instantiate the obstacle at the calculated position.
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        spawnedObstacles.Add(obstacle);
    }
}
