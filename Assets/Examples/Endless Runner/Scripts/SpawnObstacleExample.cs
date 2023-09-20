using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacleExample : MonoBehaviour
{
    public GameObject[] obstaclePrefabs; // Array of obstacle prefabs.
    public Transform player;             // Reference to the player Transform.
    public Transform plane;              // Reference to the Plane prefab's Transform.
    public float spawnInterval = 2f;     // Time interval between obstacle spawns.
    public float minSpawnDistance = 10f; // Minimum distance between spawns.
    public float yOffsetVariation = 0.3f; // Maximum variation in the y-axis position.
    public float xOffsetVariation = 1.5f; // Maximum variation in the x-axis position within the width of the Plane.
    public float zOffsetVariation = 0.3f; // Maximum variation in the z-axis position.
    public float scaleVariation = 0.2f;   // Maximum variation in scale.
    public int maxSpawnCount = 10;        // Maximum number of obstacles to spawn ahead.

    private float nextSpawnTime;
    private Vector3 lastSpawnPosition;
    private List<GameObject> spawnedObstacles = new List<GameObject>();

    private void Start()
    {
        nextSpawnTime = Time.time + spawnInterval;
        lastSpawnPosition = player.position;

        // Spawn multiple obstacles at the beginning.
        for (int i = 0; i < maxSpawnCount; i++)
        {
            SpawnRandomObstacle();
        }
    }

    private void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            // Calculate the distance between the player's current position
            // and the last spawn position.
            float distance = Mathf.Abs(player.position.x - lastSpawnPosition.x);

            if (distance >= minSpawnDistance)
            {
                SpawnRandomObstacle();
                nextSpawnTime = Time.time + spawnInterval;
            }
        }

        // Remove obstacles that are behind the player.
        RemoveObstaclesBehindPlayer();
    }

    private void SpawnRandomObstacle()
    {
        // Randomly select an obstacle prefab from the array.
        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];

        // Calculate random variations for y, x, and z positions.
        float yOffset = Random.Range(-yOffsetVariation, yOffsetVariation);
        float xOffset = Random.Range(-xOffsetVariation, xOffsetVariation);
        float zOffset = Random.Range(-zOffsetVariation, zOffsetVariation);

        // Calculate a random scale variation.
        float scale = Random.Range(1f - scaleVariation, 1f + scaleVariation);

        // Calculate the X-axis position relative to the player's position.
        float planeWidth = plane.localScale.x;
        float spawnXPosition = player.position.x + minSpawnDistance + xOffset * planeWidth;

        // Use the player's Y and Z positions.
        Vector3 spawnPosition = new Vector3(spawnXPosition, player.position.y + yOffset, player.position.z + zOffset);

        // Instantiate the obstacle with the calculated position and scale.
        GameObject obstacle = Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        obstacle.transform.localScale *= scale;

        // Update the last spawn position.
        lastSpawnPosition = spawnPosition;

        // Add the spawned obstacle to the list.
        spawnedObstacles.Add(obstacle);
    }

    private void RemoveObstaclesBehindPlayer()
    {
        for (int i = spawnedObstacles.Count - 1; i >= 0; i--)
        {
            if (spawnedObstacles[i].transform.position.x < player.position.x - minSpawnDistance)
            {
                // Remove obstacles that are behind the player.
                Destroy(spawnedObstacles[i]);
                spawnedObstacles.RemoveAt(i);
            }
        }
    }
}
