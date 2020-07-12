using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] Transform[] waypoints;
    int waypoint = 0;

    private void Start() {
        NextLocation();
    }

    public void NextLocation() {
        transform.position = waypoints[waypoint].position;
        waypoint++;
    }
}
