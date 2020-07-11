using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlField : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D other) {
        if(other.CompareTag("Player")) {
            other.GetComponent<CharacterController>().OutOfControl();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            other.GetComponent<CharacterController>().InControl();
        }
    }
}
