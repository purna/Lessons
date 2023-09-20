using UnityEngine;

public class FloatObject : MonoBehaviour
{
    public Rigidbody rb;
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(ray, 2))
        {
            FloatUp();
        }
    }
    void FloatUp()
    {
        Vector3 forceAmount = new Vector3(0, 20, 0);
        rb.AddForce(forceAmount);
    }
}