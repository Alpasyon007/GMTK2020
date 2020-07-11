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

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Control")) {
            NextLocation();
        }
    }

    void NextLocation() {
        transform.position = waypoints[waypoint].position;
        waypoint++;
    }
}
