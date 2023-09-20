using UnityEngine;

public class FinishLineSpawner : MonoBehaviour
{
    public GameObject finishLinePrefab; // Reference to the finish line prefab.
    public Transform planeEnd; // Reference to the end point of the plane.

    private void Start()
    {
        // Spawn the finish line at the end point of the plane.
        Instantiate(finishLinePrefab, planeEnd.position, Quaternion.identity);
    }
}
