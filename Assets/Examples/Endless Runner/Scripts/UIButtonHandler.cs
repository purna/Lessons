using UnityEngine;
using UnityEngine.UI;

public class UIButtonHandler : MonoBehaviour
{
    public EndlessRunnerManager playerController;


    public Button gameStartButton; // Reference to the UI button.


    private void Start()
    {
        //startButton.onClick.AddListener(StartGame);
    }

    public void StartGame()
    {
        // Call the StartGame function in the PlayerEndlessRunner script.
       playerController.StartGame();



        // Hide the button when it's clicked.
        if (gameStartButton != null)
        {
            gameStartButton.gameObject.SetActive(false);
        }
    }
}
