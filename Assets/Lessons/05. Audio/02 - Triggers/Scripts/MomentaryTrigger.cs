using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MomentaryTrigger : MonoBehaviour
{
    public AudioSource trigSource;


    void Start()
    {
        trigSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        trigSource.Play();
    }

    private void OnTriggerExit(Collider other)
    {
        trigSource.Stop();
    }
}
