using System.Collections;
using UnityEngine;

public class AudioFadeIn : MonoBehaviour
{
    public AudioSource audioSource;
    public float fadeTime = 1f;

    private float startVolume;
    private float targetVolume = 1f;

    private void Start()
    {

        audioSource.mute = false;
        startVolume = audioSource.volume;
        audioSource.volume = 0f;
      
    }

    public void FadeInButton()
    {
        Debug.Log("fade in");
        StartCoroutine(FadeIn());
    }

    public void FabeInStart()
    {
        StartCoroutine(FadeIn());
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeTime)
        {
            audioSource.volume = Mathf.Lerp(startVolume, targetVolume, elapsedTime / fadeTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        audioSource.volume = targetVolume;
    }
}
