using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildScript : ParentScript
{

    void Start()
    {
        // some code
    }

    void Update()
    {
        // calling SayHello() method every frame
        ParentScript.SayHello();
    }

}