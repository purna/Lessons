using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndlessRunnerPlayerController : MonoBehaviour
{

    [Tooltip("Base forward movement speed.")]
    public float baseForwardSpeed = 5f;

    [Tooltip("Forward movement speed when speed boost is active.")]
    public float boostedForwardSpeed = 8f;

    [Tooltip("Forward movement speed.")]
    public float forwardSpeed = 5f; // Forward movement speed.

    [Tooltip("Sideways movement speed.")]
    public float sidewaysSpeed = 2f;  // Sideways movement speed.

    [Tooltip("Height of the jump.")]
    public float jumpHeight = 2f; // Height of the jump.

    [Tooltip("Gravity acceleration.")]
    public float gravity = -9.81f; // Gravity acceleration.

    [Tooltip("Speed reduction when pressing the down arrow.")]
    public float slowdownSpeed = 2f; // Speed reduction when pressing the down arrow.

    [Tooltip("Ground detection radius.")]
    public float groundDetectionRadius = 0.2f;

    [Tooltip("Material when grounded.")]
    public Material groundedMaterial;

    [Tooltip("Material when not grounded.")]
    public Material notGroundedMaterial;

    private CharacterController characterController;
    private float verticalVelocity;
    private bool canMove = false; // Flag to control movement.
    private bool speedBoostActive = false;
    private Renderer playerRenderer; // Reference to the player's renderer.



    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerRenderer = GetComponent<Renderer>(); // Get the renderer component.
        playerRenderer.material = groundedMaterial; // Set initial material.

    }

    private void Update()
    {
        if (canMove)
        {
            // Handle player movement.
            HandleMovement();

            // Speed up if the UpArrow key is pressed.
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                SpeedUp();
            }
        }
    }

    public void StartGame()
    {
        canMove = true; // Allow movement when the game starts.
    }


    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Calculate movement direction.
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, 1f).normalized;

        // Move the player forward.
        float currentForwardSpeed = speedBoostActive ? boostedForwardSpeed : baseForwardSpeed;
        Vector3 forwardMovement = transform.forward * currentForwardSpeed * Time.deltaTime;

        // Move the player left or right.
        Vector3 sidewaysMovement = transform.right * sidewaysSpeed * Time.deltaTime * horizontalInput;

        //Debug.Log(characterController.isGrounded);


        // Check for ground detection.
        bool isGrounded = CheckGrounded();

        // Change material based on grounded state.
        if (isGrounded)
        {
            playerRenderer.material = groundedMaterial; // Set to grounded material.
        }
        else
        {
            playerRenderer.material = notGroundedMaterial; // Set to not grounded material.
        }


        // Apply gravity only when not grounded.
        if (!isGrounded)
        {
            verticalVelocity += gravity * Time.deltaTime;
        }
        else
        {
            // Reset vertical velocity when grounded to prevent falling through.
            verticalVelocity = -0.1f; // Apply a slight downward force to stick to the ground.


            // Jumping
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = Mathf.Sqrt(2f * jumpHeight * Mathf.Abs(gravity));
            }
        }

        // Apply movement forces with vertical velocity.
        Vector3 movement = (forwardMovement + sidewaysMovement) + Vector3.up * verticalVelocity * Time.deltaTime;
        characterController.Move(movement);

        // Slowing down
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Slowdown();
        }
    }


    private void Slowdown()
    {
        // Reduce the player's forward speed.
        forwardSpeed -= slowdownSpeed;

        // Ensure the speed doesn't go below zero.
        forwardSpeed = Mathf.Max(forwardSpeed, 0f);
    }

    private void SpeedUp()
    {
        // Activate the speed boost when the UpArrow key is pressed.
        speedBoostActive = true;
    }


    private bool CheckGrounded()
    {
        // Create a raycast to check if the player is grounded.
        RaycastHit hit;
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f; // Slightly above the player's position.

        if (Physics.SphereCast(rayOrigin, groundDetectionRadius, Vector3.down, out hit, 0.2f))
        {
            return true;
        }

        return false;
    }

    public ScorePlayerManager scoreManager; // Reference to the ScoreManager script.

    /*
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Check if the collision was with a wall.
        if (hit.gameObject.CompareTag("Box"))
        {
            // Check if the collision has already been processed.
            if (!hasCollided)
            {
                Debug.Log("ouch");
                // Call the function to remove a point from the score.
                scoreManager.RemoveScore(1);
                // Set the flag to true to indicate that the collision has been processed.
                hasCollided = true;
            }

        }
    }
    */
}
