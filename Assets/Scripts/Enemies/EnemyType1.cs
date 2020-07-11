using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1 : MonoBehaviour {
    [SerializeField] Transform player;
    [SerializeField] Transform control;
    [SerializeField] GameObject bullet;
    [SerializeField] float speed = 200f;
    [SerializeField] float nextWaypointDist = 3f;
    [SerializeField] private float fireRate = 2f;
    private float canFire = -1f;

    Transform target;

    Path path;
    int currentWaypoint = 0;
    bool pathEnd = false;

    Seeker seeker;
    Rigidbody2D rb;

    float time;
    float disToPlayer;
    float disToControl;

    private void Start() {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player").transform;
        control = GameObject.Find("Control").transform;
        target = player;

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
        disToPlayer = Vector2.Distance(player.position, transform.position);
        disToControl = Vector2.Distance(control.position, transform.position);

        if (disToPlayer > disToControl + 1) {
            target = control.transform;
        } else {
            target = player.transform;
        }

        if(Vector2.Distance(target.position, transform.position) < 2 && Time.time > canFire) {
            canFire = Time.time + fireRate;
            Shoot();
        }

        time += Time.deltaTime / 0.2f;
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.AngleAxis(angle, Vector3.forward), time);
    }

    void Shoot() {
        GameObject.Instantiate(bullet, transform.position, transform.rotation);
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