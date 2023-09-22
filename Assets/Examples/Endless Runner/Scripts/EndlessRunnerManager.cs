using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class EndlessRunnerManager : MonoBehaviour
{

    public EndlessRunnerPlayerController playerController;
    public Text countdownText;          // Reference to the UI text for countdown display
    public CountdownTimer countdownTimer; // Reference to the countdown timer script.
    public PlayerRespawn respawn;
    

    private bool isGameStarted; // Flag to track if the game has started.


   
    private void Start()
    {
        isGameStarted = false;

        // Hide the countdown text initially.
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(false);
        }
    }




    public void StartGame()
    {
        
        if (isGameStarted == false)
        {
            playerController.StartGame();

            isGameStarted = true;
        }

        


        // Show the countdown text and start the timer.
        if (countdownText != null)
        {
            countdownText.gameObject.SetActive(true);
        }

        // Start the countdown timer.
        if (countdownTimer != null)
        {
            countdownTimer.StartCountdown();
        }
    }


    public void GameOver()
    {

        isGameStarted = false;
        //respawn.PlayerRespawn();
    }


   
}
