using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTimeTrigger : MonoBehaviour
{
    public AudioSource trigSource;
    public AudioClip sound;
    public bool played1x = false;




    private void OnTriggerEnter(Collider other)
    {
        if (played1x == false)
        {
            trigSource.PlayOneShot(sound);
            played1x = true;
        }
        
    }


}
