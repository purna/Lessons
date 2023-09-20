using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        UnityEngine.Vector3 relativePos = target.position - transform.position;
        transform.rotation = Quaternion.LookRotation(relativePos);
    }
}

