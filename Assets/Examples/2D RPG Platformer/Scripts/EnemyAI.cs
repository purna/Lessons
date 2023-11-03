using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Platformer
{
    public class EnemyAI : MonoBehaviour
    {


        /*
        //Verions 1

        public float moveSpeed = 1f; 
        public LayerMask ground;
        public LayerMask wall;

        private new Rigidbody2D rigidbody; 
        public Collider2D triggerCollider;
        
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
        }

        void FixedUpdate()
        {
            if(!triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
            {
                Flip();
            }
        }
        
        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }
        */


        //version 1
        public float moveSpeed = 1f;
        public float detectionRange = 5f; // The range at which the enemy detects the player.
        public float followDuration = 3f; // The duration the enemy follows the player.
        public LayerMask ground;
        public LayerMask wall;

        private new Rigidbody2D rigidbody;
        private Collider2D triggerCollider;
        private Transform player;
        private bool isFollowingPlayer = false;
        private float followTimer = 0f;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            triggerCollider = GetComponent<Collider2D>();
            player = GameObject.FindGameObjectWithTag("Player").transform; // Change "Player" to the tag you use for the player object.
        }

        void Update()
        {
            GameObject existingPlayer = GameObject.FindGameObjectWithTag("Player");
            if (existingPlayer != null)
            {

                if (IsPlayerInRange() && !isFollowingPlayer)
                {
                    isFollowingPlayer = true;
                    followTimer = followDuration;
                }

                if (isFollowingPlayer)
                {
                    FollowPlayer();
                }
                else
                {
                    rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
                }
            }
        }

        void FixedUpdate()
        {
            if (!triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
            {
                Flip();
            }
        }

        private void FollowPlayer()
        {
            if (followTimer > 0)
            {
                // Calculate direction to the player and move towards them.
                float direction = (player.position.x - transform.position.x > 0) ? 1 : -1;
                rigidbody.velocity = new Vector2(moveSpeed * direction, rigidbody.velocity.y);
                followTimer -= Time.deltaTime;
            }
            else
            {
                isFollowingPlayer = false;
            }
        }

        private bool IsPlayerInRange()
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            return distanceToPlayer <= detectionRange;
        }

        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }
    }
}
