using UnityEngine;
using System.Collections;

public class YetAnotherScript : MonoBehaviour
{
    public int numberOfPlayerDeaths = 3;


    public  void SayHello()
    {
        Debug.Log($"Another Hey there {numberOfPlayerDeaths} !");
    }
}