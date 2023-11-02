using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class WaypointChecker : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Transform waypoint; // Reference to the waypoint's transform
    public float passingDistance = 1.0f; // The distance at which the player is considered to have passed the waypoint

    private bool hasPassedWaypoint = false;
    private Vector3 waypointPosition;

    private void Update()
    {
        if (!hasPassedWaypoint)
        {
            float distance = Vector3.Distance(player.position, waypoint.position);

            if (distance <= passingDistance)
            {
                hasPassedWaypoint = true;
                Debug.Log("3. Player has passed the waypoint!");
                // You can add your logic here for what to do when the player passes the waypoint.
                waypointPosition = waypoint.position;

            }
        }

    }
}