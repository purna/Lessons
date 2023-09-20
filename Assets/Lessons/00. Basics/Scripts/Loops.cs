using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loops : MonoBehaviour
{

    new public GameObject gameObject;
    public Vector3 targets;
    new bool enabled = true;
    int iterationCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < iterationCount; i++)
        {
            // Code to be repeated.
        }


        Vector3[] targets = { Vector3.zero, Vector3.one, Vector3.up };
        foreach (Vector3 target in targets)
        {
            // Code specific to each target in the targets collection goes here.
        }


        while (gameObject.activeSelf)
        {
            // Code that will repeat until the GameObject is no longer active.
        }


        do
        {
            // Code that runs until the MonoBehaviour is disabled.
            enabled = false;

        } while (enabled);

        /*
        Target selectedTarget = null;


       
                foreach (Target target in targets)
                {
                    if (target.isActive)
                    {
                        selectedTarget = target;
                        break;
                    }
                }

        */
        /*
        void DetonateActiveTargets(Target[] targets)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                Target currentTarget = targets[i];
                if (!currentTarget.isActive)
                    continue;
                currentTarget.Detonate();
            }
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
