using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] float speed = 200f;
    [SerializeField] float nextWaypointDist = 3f;
    [SerializeField] LayerMask ground;

    Path path;
    int currentWaypoint = 0;
    bool pathEnd = false;

    Seeker seeker;
    Rigidbody2D rb;

    Vector2 target_position;
    float time;

    private void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        target_position = new Vector2(target.position.x, target.position.y);

        InvokeRepeating("UpdatePath", 0f, 0.5f);
    }

    void UpdatePath() {
        seeker.StartPath(rb.position, target.position, PathComplete);
    }

    void PathComplete(Path p) {
        if (!p.error) {
            path = p;
            currentWaypoint = 0;
        }
    }

    private void Update() {
        time += Time.deltaTime / 3;
        rb.rotation = Mathf.Lerp(0, Mathf.Atan2((target_position - rb.position).y, (target_position - rb.position).x) * Mathf.Rad2Deg - 90f, time);
    }

    private void FixedUpdate() {

        if (path == null) {
            return;
        }

        if (currentWaypoint >= path.vectorPath.Count) {
            pathEnd = true;
            return;
        } else {
            pathEnd = false;
        }

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;
        Vector2 force = direction * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDist) {
            currentWaypoint++;
        }
    }
}
