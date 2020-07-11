using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType1Stats : MonoBehaviour
{
    [SerializeField] int enemyHealth = 30;
    [SerializeField] Animator animator;

    public void HealEnemy(int heal) {
        enemyHealth = Mathf.Clamp(enemyHealth + heal, 0, enemyHealth);
    }

    public void DamageEnemy(int damage) {
        enemyHealth = Mathf.Clamp(enemyHealth - damage, 0, enemyHealth);
        if (enemyHealth == 0) {
            StartCoroutine(KillAnimation());
        }
    }

    IEnumerator KillAnimation() {
        animator.SetTrigger("Explode");
        yield return new WaitForSeconds(0.3f);
        KillEnemy();
    }

    void KillEnemy() {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Player>().DamagePlayer(10);
            StartCoroutine(KillAnimation());
        } else if(other.gameObject.CompareTag("Control")) {
            other.gameObject.GetComponent<Control>().DamageControl(5);
            StartCoroutine(KillAnimation());
        }
    }
}   
