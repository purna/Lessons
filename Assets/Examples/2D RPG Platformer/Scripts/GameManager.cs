using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Platformer
{
    public class GameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public GameObject playerGameObject;
        private PlayerController player;
        public GameObject deathPlayerPrefab;
        public Text coinText;

        //public Transform[] respawnPoints; // Assign your respawn waypoints to this array
        //public float respawnDelay = 2.0f; // The delay before respawning the player
        //private Transform lastWaypoint; // Store the last waypoint where the player respawned

        //private bool hasPassedWaypoint = false;
        public RespawnManager respawnManager; // Reference to the RespawnManager script


        void Start()
        {
            player = GameObject.Find("Player").GetComponent<PlayerController>();
        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();
            if(player.deathState == true)
            {
                
                playerGameObject.SetActive(false);
                //Change player to dead player prefab
                GameObject deathPlayer = (GameObject)Instantiate(deathPlayerPrefab, playerGameObject.transform.position, playerGameObject.transform.rotation);
                deathPlayer.transform.localScale = new Vector3(playerGameObject.transform.localScale.x, playerGameObject.transform.localScale.y, playerGameObject.transform.localScale.z);
                player.deathState = false;
                

                // Call the RespawnPlayer method of the RespawnManager script
                if (respawnManager != null)
                {
                    respawnManager.RespawnPlayer();

                }
                else
                {
                    // Reload the scene after 3 seconds
                    Invoke("ReloadLevel", 3);
                }


            }
        }

        private void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }

       
    }
}
