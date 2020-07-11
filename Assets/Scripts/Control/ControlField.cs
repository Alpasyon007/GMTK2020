using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlField : MonoBehaviour
{
    private void Update() {
        transform.position = GameObject.Find("Control").transform.position;
        transform.rotation = GameObject.Find("Control").transform.rotation;
    }

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
