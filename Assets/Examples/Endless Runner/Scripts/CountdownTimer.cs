using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float gameTime = 60f; // Total game time in seconds.
    public float checkpointDistance = 100f; // Distance required to pass the checkpoint.
    public Transform player; // Reference to the player's Transform.
    public Text countdownText; // Reference to the UI text for countdown display.
    public EndlessRunnerManager playerController; // Reference to the player controller script.

    private float timer;
    private bool gameEnded;

    private void Start()
    {
        // Disable the countdown text initially.
        countdownText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!gameEnded)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                // Game over condition: Time ran out.
                EndGame();
            }
            else
            {
                // Check if the player has passed the checkpoint.
                if (player.position.z >= checkpointDistance)
                {
                    // Player passed the checkpoint, reset the timer.
                    timer = gameTime;
                }
            }
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        countdownText.text = "Game Over";

        // Call the function to end the game in the PlayerEndlessRunner script.
        playerController.GameOver();
    }

    // Coroutine to update the countdown text every second.
    private IEnumerator UpdateCountdownTextCoroutine()
    {
        while (!gameEnded && timer > 0f)
        {
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

            yield return new WaitForSeconds(1f); // Wait for one second.
        }
    }

    // Public method to start the countdown.
    public void StartCountdown()
    {
        gameEnded = false;
        timer = gameTime;
        countdownText.gameObject.SetActive(true);
        StartCoroutine(UpdateCountdownTextCoroutine()); // Start the coroutine.
    }
}
