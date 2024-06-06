using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopdownGameManager : MonoBehaviour
    {
        public int coinsCounter = 0;

        public int livesCounter = 3;

        public GameObject playerGameObject;
        private TopDownCharacterController player;


        public Text coinText;
        public Text livesText;

        //public Transform[] respawnPoints; // Assign your respawn waypoints to this array
        //public float respawnDelay = 2.0f; // The delay before respawning the player
        //private Transform lastWaypoint; // Store the last waypoint where the player respawned

        //private bool hasPassedWaypoint = false;
        public RespawnManager respawnManager; // Reference to the RespawnManager script

        
        void Start()
        {
            player = GameObject.Find("Player").GetComponent<TopDownCharacterController>();
        }

        void Update()
        {
            coinText.text = coinsCounter.ToString();
            livesText.text = livesCounter.ToString();

            if (player.deathState == true)
            {
                //Remove a life
                livesCounter = livesCounter - 1;

                playerGameObject.SetActive(false);
                //Change player to dead player prefab
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
