using UnityEngine;
using System.Collections;

public class MulticastScript : MonoBehaviour
{
    delegate void MultiDelegate();
    MultiDelegate myMultiDelegate;

    new public Renderer renderer;


    void Start()
    {
        myMultiDelegate += PowerUp;
        myMultiDelegate += TurnRed;

        if (myMultiDelegate != null)
        {
            myMultiDelegate();
        }
    }

    void PowerUp()
    {
        print("Orb is powering up!");
        //Debug.Log("Orb is powering up!");
    }

    void TurnRed()
    {
        renderer.material.color = Color.red;
    }
}