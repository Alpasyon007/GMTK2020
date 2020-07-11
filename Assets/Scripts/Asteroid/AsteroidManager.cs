using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField]GameObject[] astreoids;
    [SerializeField] private float SpawnRate = 2f;
    private float canSpawn = -1f;

    private void Update() {
        if(Time.time > canSpawn) {
            canSpawn = Time.time + SpawnRate;
            GameObject.Instantiate(astreoids[Random.Range(5,0)], transform.position + new Vector3(transform.position.x + Random.Range(20, -20), 0), transform.rotation);
        }
    }
}
