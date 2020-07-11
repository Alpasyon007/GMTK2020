using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealField : MonoBehaviour
{
    [SerializeField] private float HealRate = 0.5f;
    private float canHeal = -1f;
    bool heal = false;

    private void FixedUpdate() {
        if (Time.time > canHeal && heal) {
            canHeal = Time.time + HealRate;
            GameObject.Find("Player").GetComponent<Player>().HealPlayer(1);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<CharacterController>().OutOfControl();
            heal = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<CharacterController>().InControl();
            heal = true;
        } else {
            Destroy(other.gameObject);
        }
    }
}
