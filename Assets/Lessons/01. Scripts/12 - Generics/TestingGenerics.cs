
using System;
using UnityEngine;

public class TestingGenerics : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //example showing a basic fuction
        /*
        int[] basicArray = CreateArray(5, 6);
        Debug.Log(basicArray.Length + " " + basicArray[0] + " " + basicArray[1]);
        Debug.Log(basicArray.GetType());
        */
        CreateArray(7, 8);


        int[] intArray = CreateArray<int>(5, 6);
        Debug.Log(intArray.Length + " " + intArray[0] + " " + intArray[1]);
        Debug.Log(intArray.GetType());

        string[] objectArray = CreateArray<string>("Hello", "world");

        Debug.Log(objectArray.Length + " " + objectArray[0] + " " + objectArray[1]);
        Debug.Log(objectArray.GetType());
        
    }
    // Example using generics

    private T[] CreateArray<T>(T firstElement, T secondElement)
    {
        return new T[] { firstElement, secondElement };
    }

    /*
    private int[] CreateArray(int firstElement, int secondElement)
    {
        return new int[] { firstElement, secondElement };
    }

    private string[] CreateArray(string firstElement, string secondElement)
    {
        return new string[] { firstElement, secondElement };
    }
     */

}
