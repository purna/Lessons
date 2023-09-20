using UnityEngine;
using System.Collections;

public class AnotherScript : MonoBehaviour
{
    public int playerScore = 9001;

    public void SayHello()
    {
        Debug.Log($"Another Hey there {playerScore} !");
    }

}