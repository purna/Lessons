using UnityEngine;

public class PlatformSwitch : MonoBehaviour
{
    public MovingPlatforms platform; // Reference to the MovingPlatform script
    public bool startMoving = true; // Value to set the platform's isMoving state

    // This method can be called to change the platform's movement state
    public void TriggerPlatform()
    {
        if (platform != null)
        {
            platform.SetIsMoving(startMoving);
        }
    }

    // Optional: if you want to trigger on collision or trigger, uncomment and use
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player")) // Trigger when the player enters
        {
            TriggerPlatform();
        }
    }
}
