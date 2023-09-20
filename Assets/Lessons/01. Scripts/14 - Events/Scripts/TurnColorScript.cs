using UnityEngine;
using System.Collections;

public class TurnColorScript : MonoBehaviour
{

    new public Renderer renderer;

    void OnEnable()
    {
        EventManager.OnClicked += TurnColor;
    }


    void OnDisable()
    {
        EventManager.OnClicked -= TurnColor;
    }


    void TurnColor()
    {
        Color col = new Color(Random.value, Random.value, Random.value);
        renderer.material.color = col;
    }
}
