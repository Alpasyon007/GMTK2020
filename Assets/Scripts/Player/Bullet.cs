using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour { 
    [SerializeField] float bulletSpeed = 50f;

    private void Start() {
        StartCoroutine(KillSelf());
    }

    void Update()
    {
        transform.Translate(Vector2.up * bulletSpeed * Time.deltaTime);
    }
    
    IEnumerator KillSelf() {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("EnemyType1")) {
            other.GetComponent<EnemyType1Stats>().DamageEnemy(10);
            Destroy(this.gameObject);
        }   else if (other.CompareTag("EnemyType2")) {
            other.GetComponent<EnemyType2Stats>().DamageEnemy(10);
            Destroy(this.gameObject);
        } else if (other.CompareTag("Control")) {
            other.GetComponent<Control>().DamageControl(5);
            Destroy(this.gameObject);
        }
    }
}
