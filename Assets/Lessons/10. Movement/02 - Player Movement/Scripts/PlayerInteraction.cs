using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerInteraction : MonoBehaviour
    {

        [HideInInspector]
        public bool deathState = false;


        public LevelManager gameManager;


        void Start()
        {
            gameManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();

        }


        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                deathState = true; // Say to GameManager that player is dead
            }
            else
            {
                deathState = false;
            }


        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
                Debug.Log("Player has collected a coin!");
            }
        }
    }

}

