using UnityEngine;
public class Mover : MonoBehaviour
{
    public float speed = 5f;
    void Update()
    {
        transform.position += Vector3.forward * (speed * Time.deltaTime);
    }
}