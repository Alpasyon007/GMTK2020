using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float bulletSpeed = 10f;

    private void Start() {
        StartCoroutine(KillSelf());
    }

    void Update()
    {
        rb.AddForce(gameObject.transform.up * bulletSpeed);
    }
    
    IEnumerator KillSelf() {
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }
}
