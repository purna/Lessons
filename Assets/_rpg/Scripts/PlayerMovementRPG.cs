using UnityEngine;

public class PlayerMovementRPG : MonoBehaviour
{
    public float moveSpeed = 5f;        // Horizontal movement speed
    public float jumpForce = 10f;       // Jump force for vertical movement
    public Rigidbody2D rb;              // Rigidbody2D component

    private Vector2 movement;           // Store player movement input
    private bool isGrounded;            // Check if the player is grounded
    private bool canDoubleJump;         // Check if the player can double jump
    public Transform groundCheck;       // Ground check position
    public float groundCheckRadius = 0.2f; // Radius for checking ground
    public LayerMask groundLayer;       // Layer used to detect ground

    void Update()
    {
        // Get the horizontal input (A/D or Left/Right arrow keys)
        movement.x = Input.GetAxisRaw("Horizontal");

        // Flip the character sprite based on movement direction
        if (movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // Face left
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // Face right
        }

        // Jump input using the Space Bar (or "Jump" button in Input Manager)
        if (Input.GetKeyDown(KeyCode.Space))  // Spacebar specifically for jump
        {
            Debug.Log("jump");
            if (isGrounded)
            {
                Debug.Log("is grounded");
                Jump();
                canDoubleJump = true; // Allow double jump after the first jump
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false; // Disable double jump after second jump
            }
        }
    }

    void FixedUpdate()
    {
        // Apply horizontal movement using velocity instead of MovePosition
        rb.velocity = new Vector2(movement.x * moveSpeed, rb.velocity.y);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void FixedUpdate2()
    {
        // Apply horizontal movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        // Check if the player is grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void Jump()
    {
        // Apply vertical force to jump
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);


        // Debug to check if the jump function is being called and the velocity is being set
        Debug.Log("Jump executed. Velocity: " + rb.velocity);
        

    }
}
