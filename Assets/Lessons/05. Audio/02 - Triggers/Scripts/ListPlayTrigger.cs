using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListPlayTrigger : MonoBehaviour
{
    public AudioSource trigSource;
    public AudioClip[] soundList;
    public AudioClip sound;
    public int count = 0;



    private void OnTriggerEnter(Collider other)
    {
        if (count == 10)
        {
            count = 0;
        }

        trigSource.PlayOneShot(soundList[count]);
        count++;

    }


}
