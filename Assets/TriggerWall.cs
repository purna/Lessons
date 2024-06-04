using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //when object exit the trigger, put it to the assigned layer and sorting layers
    //used in the stair objects for player to travel between layers
    public class TriggerWall : MonoBehaviour
    {
        public GameObject layer;

        private void OnTriggerEnter2D(Collider2D other)
        {

            Debug.Log("enter");
            if (other.gameObject.tag == "Player")
            {
                layer.gameObject.SetActive(false);
            }

        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("exit");
            if (other.gameObject.tag == "Player")
            {
                layer.gameObject.SetActive(true);
            }

        }

    }
}
