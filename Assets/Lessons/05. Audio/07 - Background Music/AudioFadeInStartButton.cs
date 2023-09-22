using UnityEngine;

public class AudioFadeInStartButton : MonoBehaviour
{
    public AudioFadeIn audioFadeIn;

    void StartButton()
    {
        audioFadeIn.FadeInButton();
    }
}