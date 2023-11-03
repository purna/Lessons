using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownPlayer : MonoBehaviour
    {
        private TopdownGameManager gameManager;

        public HealthBar healthBar;

        void Start()
        {
            gameManager = GameObject.Find("GameManager").GetComponent<TopdownGameManager>();

          
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                gameManager.coinsCounter += 1;
                Destroy(other.gameObject);
                Debug.Log("Player has collected a coin!");
            }

            if (other.gameObject.tag == "Finish")
            {
                gameManager.Invoke("ReloadLevel", 3);
            }

            if (other.gameObject.tag == "Enemy")
            {
                //deathState = true; // Say to GameManager that player is dead
                healthBar.TakeDamage(10);
                Debug.Log("Player has 10 damage");
            }
            else
            {
                //death
            }
        }

    }
}