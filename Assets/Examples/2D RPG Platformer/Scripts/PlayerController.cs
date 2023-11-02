using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;

        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
        public Transform groundCheck;

        private new Rigidbody2D rigidbody;
        private Animator animator;
        private GameManager gameManager;


        private bool isFalling = false;
        private float fallStartTime = 0f;
        private float fallThreshold = 1.0f; // Adjust this value to set the fall time threshold.


        //public WaypointChecker waypointChecker;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

            if (deathState)
            {
                // Handle player death logic here, such as restarting the level or showing a game over screen.
                // You might want to disable player movement and animations, play death sound, etc.
                // For this example, we'll just reset the player's position.
                gameManager.respawnManager.RespawnPlayer();
            }
            else
            {
                // Check if the player is falling
                if (IsFalling())
                {
                    // The player is falling, start timing the fall.
                    if (!isFalling)
                    {
                        isFalling = true;
                        fallStartTime = Time.time;
                    }

                    // Check if the fall duration has exceeded the threshold
                    if (Time.time - fallStartTime >= fallThreshold)
                    {
                        deathState = true;
                    }
                }
                else
                {
                    // The player is not falling, reset the fall timer.
                    isFalling = false;
                }
            }
        }


        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            if (Input.GetButton("Horizontal")) 
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            }

            if(Input.GetKeyDown(KeyCode.Space) && isGrounded )
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }

            if (!isGrounded)
            {
                animator.SetInteger("playerState", 2); // Turn on jump animation
            }
              

            if(facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        bool IsFalling()
        {
            // You can implement your own logic here to determine if the player is falling.
            // For example, you can check if the player's vertical velocity is negative.
            return GetComponent<Rigidbody>().velocity.y < 0;
        }

        private void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
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

            if (other.gameObject.tag == "Finish")
            {
                gameManager.Invoke("ReloadLevel", 3);
            }
        }
    }

}


