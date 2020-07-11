    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] int playerHealth = 100; //Currently an int and 100, may change to a float.
    [SerializeField] HealthBar healthBar;

    private void Start() {
        healthBar.SetMaxHeatlh(playerHealth);
    }

    public void HealPlayer(int heal) {
        playerHealth = Mathf.Clamp(playerHealth + heal, 0, 100);
        healthBar.SetHealth(playerHealth);
    }

    public void DamagePlayer(int damage) {
        playerHealth = Mathf.Clamp(playerHealth - damage, 0, 100);
        healthBar.SetHealth(playerHealth);
        if (playerHealth == 0) {
            KillPlayer();
        }
    }

    void KillPlayer() {
        Destroy(this.gameObject);
    }
}
