using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] Camera cam;

    Vector2 mousePos;
    Vector2 up;
    Vector2 right;
    Vector2 left;
    Vector2 down;
    Vector2[] array = {Vector2.up, Vector2.right, Vector2.left, Vector2.down};

    private void Start() {
        up = Vector2.up;
        right = Vector2.right;
        left = Vector2.left;
        down = Vector2.down;
    }

    void Update() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            Fire();
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            rb.AddForce(up * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            rb.AddForce(right * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            rb.AddForce(left * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            rb.AddForce(down * speed);
        }
    }

    private void FixedUpdate() {
        rb.rotation = Mathf.Atan2((mousePos - rb.position).y, (mousePos - rb.position).x) * Mathf.Rad2Deg - 90f;
    }

    void Fire() {
        GameObject.Instantiate(bullet, transform.position, transform.rotation);
    }

    public void OutOfControl() {
        StartCoroutine(RandomiseControls());
        Debug.Log("Out of control");
    }

    public void InControl() {
        StopCoroutine(RandomiseControls());
        up = Vector2.up;
        right = Vector2.right;
        left = Vector2.left;
        down = Vector2.down;    
    }

    IEnumerator RandomiseControls() {
            var rng = new System.Random();
            var values = Enumerable.Range(0, 4).OrderBy(x => rng.Next()).ToArray();
            up = array[values[0]];
            right = array[values[1]];
            left = array[values[2]];
            down = array[values[3]];
            yield return null;
    }
}
