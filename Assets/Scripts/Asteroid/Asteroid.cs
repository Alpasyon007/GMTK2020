using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    private void Start() {
        transform.Rotate(0, 0, Random.Range(-20, 20));
    }

    private void Update() {
        transform.Translate(Vector2.down * (Random.Range(0, 10) * 0.2f) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Player>().DamagePlayer(30);
        } else if (other.gameObject.CompareTag("EnemyType1")) {
            other.gameObject.GetComponent<EnemyType1Stats>().DamageEnemy(30);
        } else if (other.gameObject.CompareTag("EnemyType2")) {
            other.gameObject.GetComponent<EnemyType2Stats>().DamageEnemy(50);
        } else if (other.gameObject.CompareTag("Control")) {
            other.gameObject.GetComponent<Control>().DamageControl(20);
            Destroy(gameObject);
        }
    }

    public void KillAsteroid() {
        Destroy(gameObject);
    }
}
