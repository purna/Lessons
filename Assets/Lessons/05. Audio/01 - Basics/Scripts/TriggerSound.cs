using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour
{

    public AudioSource trigSource;
    public AudioClip sound;

    private void OnTriggerEnter(Collider other)
    {
        trigSource.PlayOneShot(sound);
    }

}

   