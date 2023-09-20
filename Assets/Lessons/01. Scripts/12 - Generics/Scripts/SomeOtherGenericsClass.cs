using UnityEngine;
using System;

public class SomeOtherGenericsClass : MonoBehaviour
{
    void Start()
    {
        print("SomeOtherGenericsClass");

        SomeGenericsClass myClass = new SomeGenericsClass();

        //In order to use this method you must
        //tell the method what type to replace
        //'T' with.
        //myClass.GenericMethod<int>(10);

        int result = myClass.GenericMethod<int>(10);

        print("Other: " + result);


    }
}