using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletScript : MonoBehaviour {
    [SerializeField] float bulletSpeed = 10f;

    private void Start() {
        StartCoroutine(KillSelf());
    }

    void Update() {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }

    IEnumerator KillSelf() {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Control")) {
            other.GetComponent<Control>().DamageControl(5);
            Destroy(this.gameObject);
        } else if (other.CompareTag("Player")) {
            other.GetComponent<Player>().DamagePlayer(5);
            Destroy(this.gameObject);
        }
    }
}
