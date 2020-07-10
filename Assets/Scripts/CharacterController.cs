using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] GameObject bullet;
    [SerializeField] Camera cam;

    Vector2 mousePos;


    void Update() {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetKeyDown(KeyCode.Mouse1)) {
            Fire();
        }
        if (Input.GetKey(KeyCode.UpArrow)) {
            rb.AddForce(Vector2.up * speed);
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            rb.AddForce(Vector2.right * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow)) {
            rb.AddForce(Vector2.left * speed);
        }
        if (Input.GetKey(KeyCode.DownArrow)) {
            rb.AddForce(Vector2.down * speed);
        }
    }

    private void FixedUpdate() {
        rb.rotation = Mathf.Atan2((mousePos - rb.position).y, (mousePos - rb.position).x) * Mathf.Rad2Deg - 90f;
    }

    void Fire() {
        Object.Instantiate(bullet, transform.position, transform.rotation);
    }
}
