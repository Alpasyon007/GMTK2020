using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalWaypoint : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Control")) {
            GameObject.Find("SceneLoader").GetComponent<SceneLoader>().LoadNextScene();
        }
    }
}
