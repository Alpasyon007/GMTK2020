using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] int playerHealth = 100; //Currently an int and 100, may change to a float.
    [SerializeField] HealthBar healthBar;
    [SerializeField] Texture2D cursor;
    [SerializeField] Animator animator;

    int maxHealth;

    private void Update() {
        if(Vector2.Distance(transform.position, GameObject.Find("Control").transform.position) > 15) {
            StartCoroutine(KillAnimation());
        }
    }

    private void Start() {
        maxHealth = playerHealth;
        //Cursor.SetCursor(cursor, Vector2.zero, CursorMode.Auto);
        healthBar.SetMaxHeatlh(playerHealth);
    }

    public void HealPlayer(int heal) {
        if(playerHealth < maxHealth) {
            playerHealth += heal;
        }
        healthBar.SetHealth(playerHealth);
    }

    public void DamagePlayer(int damage) {
        playerHealth = Mathf.Clamp(playerHealth - damage, 0, playerHealth);
        healthBar.SetHealth(playerHealth);
        if (playerHealth == 0) {
            StartCoroutine(KillAnimation());
        }
    }

    IEnumerator KillAnimation() {
        animator.SetTrigger("Explode");
        yield return new WaitForSeconds(0.3f);
        KillPlayer();
    }

    void KillPlayer() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(this.gameObject);
    }
}
