using UnityEngine;
using UnityEngine.UI;

public class FinishLineTrigger : MonoBehaviour
{
    public Text TextCountdown;
    public GameObject StartButton;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has entered the finish line trigger.
        if (other.CompareTag("Player"))
        {
            // Output "You win" to the UI Text component.
            TextCountdown.text = "You win!";

            // Activate the Start button.
            StartButton.SetActive(true);
        }
    }
}