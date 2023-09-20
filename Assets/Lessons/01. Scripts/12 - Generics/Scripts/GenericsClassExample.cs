using UnityEngine;
using System.Collections;
using System;

public class GenericClassExample : MonoBehaviour
{
    void Start()
    {
        print("GenericClassExample");

        //In order to create an object of a generic class, you must
        //specify the type you want the class to have.
        GenericClass<int> myClass = new GenericClass<int>();

        myClass.UpdateItem(5);

        int itemValue = myClass.GetItem();
        print("Example: " + itemValue);
    }
}