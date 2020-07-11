using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyType2Stats : MonoBehaviour
{
    [SerializeField] int enemyHealth = 50;

    public void HealEnemy(int heal) {
        enemyHealth = Mathf.Clamp(enemyHealth + heal, 0, enemyHealth);
    }

    public void DamageEnemy(int damage) {
        enemyHealth = Mathf.Clamp(enemyHealth - damage, 0, enemyHealth);
        if (enemyHealth == 0) {
            KillEnemy();
        }
    }

    void KillEnemy() {
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Player")) {
            other.gameObject.GetComponent<Player>().DamagePlayer(10);
            Destroy(this.gameObject);
        } else if(other.gameObject.CompareTag("Control")) {
            other.gameObject.GetComponent<Control>().DamageControl(5);
            Destroy(this.gameObject);
        }
    }
}   
