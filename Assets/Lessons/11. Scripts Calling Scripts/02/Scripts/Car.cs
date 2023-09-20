using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Car
{
    public string model;
    public string color;
    public int year;
    public void fullThrottle()
    {
        Debug.Log($"The {model} is going as fast as it can!");
    }
}