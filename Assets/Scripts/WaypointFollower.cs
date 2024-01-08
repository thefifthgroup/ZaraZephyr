using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{   
    // references, inializations, declarations
    [SerializeField] private GameObject[] waypoints; // field for array of waypoints
    [SerializeField] private float speed = 2f;
    private int currentWaypointIndex = 0;

    private void Update()
    {
        // to check the distance between the platform and the current waypoint 
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        // move platform directly frame by frame
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
