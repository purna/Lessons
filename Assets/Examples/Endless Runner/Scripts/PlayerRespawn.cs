using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public float respawnDelay = 5f;     // Time delay for player respawn.
    private Rigidbody playerRigidbody;
    private Vector3 initialPosition;



    public void RespawnPlayer()
    {
        // Disable the player temporarily.
        playerRigidbody.gameObject.SetActive(false);
        // Schedule the player to respawn after a delay.
        StartCoroutine(RespawnAfterDelay());
    }

    private IEnumerator RespawnAfterDelay()
    {
        yield return new WaitForSeconds(respawnDelay);
        // Reset player's position to the initial position.
        playerRigidbody.transform.position = initialPosition;
        // Re-enable the player.
        playerRigidbody.gameObject.SetActive(true);
    }
}
