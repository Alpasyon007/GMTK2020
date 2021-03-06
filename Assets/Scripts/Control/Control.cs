﻿using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Control : MonoBehaviour {
    [SerializeField] Transform target;
    [SerializeField] float speed = 200f;
    [SerializeField] float nextWaypointDist = 3f;
    [SerializeField] Animator animator;

    Path path;
    int currentWaypoint = 0;
    bool pathEnd = false;

    Seeker seeker;
    Rigidbody2D rb;

    Vector2 target_position;
    float time;

    [SerializeField] int controlHealth = 1000; //Currently an int and 100, may change to a float.
    [SerializeField] HealthBar healthBar;

    public void HealControl(int heal) {
        controlHealth = Mathf.Clamp(controlHealth + heal, 0, 1000);
        healthBar.SetHealth(controlHealth);
    }

    public void DamageControl(int damage) {
        controlHealth = Mathf.Clamp(controlHealth - damage, 0, 1000);
        healthBar.SetHealth(controlHealth);
        if (controlHealth == 0) {
            StartCoroutine(KillAnimation());
        }
    }

    IEnumerator KillAnimation() {
        animator.SetTrigger("Explode");
        yield return new WaitForSeconds(0.3f);
        KillControl();
    }

    void KillControl() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(this.gameObject);
    }

    private void Start() {
        healthBar.SetMaxHeatlh(controlHealth);
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
        time += Time.deltaTime / 3f;
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Slerp(Quaternion.identity, Quaternion.AngleAxis(angle, Vector3.forward), time);
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
        Vector2 force = direction.normalized * speed * Time.deltaTime;

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDist) {
            currentWaypoint++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Target")) {
            other.gameObject.GetComponent<Target>().NextLocation();
        }
    }
}
