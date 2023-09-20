using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Models : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Car Ford = new Car();
        Ford.model = "Mustang";
        Ford.color = "red";
        Ford.year = 1969;

        Car Opel = new Car();
        Opel.model = "Astra";
        Opel.color = "white";
        Opel.year = 2005;

        Debug.Log(Ford.model);
        Debug.Log(Opel.model);

        Opel.fullThrottle();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}