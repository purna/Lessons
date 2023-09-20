using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearInterpolation : MonoBehaviour
{
    // Start is called before the first frame update
    new public Light light;

    public float intensity;


    void Start()
    {
        // In this case, result = 4
        //float result = Mathf.Lerp(3f, 5f, 0.5f);

        //Vector3 from = new Vector3(1f, 2f, 3f);
        //Vector3 to = new Vector3(5f, 6f, 7f);

        // Here result = (4, 5, 6)
        //Vector3 result = Vector3.Lerp(from, to, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        // light.intensity = Mathf.Lerp(light.intensity, 8f, 0.5f);

        intensity = light.intensity;

        light.intensity = Mathf.Lerp(light.intensity, 30f, 0.5f * Time.deltaTime);


    }
}
