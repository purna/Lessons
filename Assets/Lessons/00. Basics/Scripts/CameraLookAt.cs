using UnityEngine;
using System.Collections;
using static Unity.VisualScripting.Member;

public class CameraLookAt : MonoBehaviour
{
    public Transform target;
    public GameObject source;

    void Update()
    {
        source.transform.LookAt(target);
    }
}