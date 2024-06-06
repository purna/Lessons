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
               
                // Assuming 'other' is the collision object or some other context where you're getting the AudioSource from
                AudioSource audioclip = other.gameObject.GetComponent<AudioSource>();

                // Play the audio clip
                audioclip.Play();

                //Hide the game object
                Renderer IsVisible = other.gameObject.GetComponent<Renderer>();
                //Hide the coin
                IsVisible.enabled = false;

                // Destroy the game object after the audio clip has finished playing
                Destroy(other.gameObject, audioclip.clip.length);

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

                if (healthBar.currentHealth == 0)
                {
                    gameManager.livesCounter -= 1;
                }


                Debug.Log("Player has 10 damage. Current health is:" + healthBar.currentHealth);
            }
            else
            {
                //death
            }
        }

    }
}