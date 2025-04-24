using UnityEngine;

public class MovingPlatformArray : MonoBehaviour
{
    public Transform platform; // The platform to move
    public Transform[] points; // Array of points for movement
    public float speed = 1.5f; // Speed of the platform

    private int currentPointIndex = 0; // Index of the current target point

    private void OnDrawGizmos()
    {
        // Draw lines between the points for visualization in the editor
        if (points != null && points.Length > 1)
        {
            for (int i = 0; i < points.Length; i++)
            {
                Transform nextPoint = points[(i + 1) % points.Length];
                Gizmos.DrawLine(points[i].position, nextPoint.position);
            }
        }
    }

    void Update()
    {
        if (points.Length < 2) return; // Ensure there are at least two points

        // Move the platform towards the current target point
        Transform targetPoint = points[currentPointIndex];
        platform.position = Vector2.MoveTowards(platform.position, targetPoint.position, speed * Time.deltaTime);

        // Check if the platform is close to the target point
        if (Vector2.Distance(platform.position, targetPoint.position) < 0.1f)
        {
            // Move to the next point in the array
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(platform.transform, true);
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.gameObject.transform.parent == platform.transform)
            {
                col.gameObject.transform.SetParent(null, true);
            }
        }
    }
}
