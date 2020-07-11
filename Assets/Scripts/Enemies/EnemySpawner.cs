using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private float RotateSpeed = 2f;
    private float Radius = 5f;

    private Vector2 centre;
    private float angle;

    Vector2 visibility;
    [SerializeField] GameObject[] enemy;
    [SerializeField] private float SpawnRate = 1f;
    private float canSpawn = -1f;

    private GameObject[] getCount_1;
    private GameObject[] getCount_2;
    int count;
    int count_1;
    int count_2;

    private void Start() {
        centre = GameObject.Find("Control").transform.position;
    }

    private void Update() {
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;

        visibility = Camera.main.WorldToViewportPoint(new Vector2(transform.position.x, transform.position.y));

        getCount_1 = GameObject.FindGameObjectsWithTag("EnemyType1");
        getCount_2 = GameObject.FindGameObjectsWithTag("EnemyType2");
        count_1 = getCount_1.Length;
        count_2 = getCount_2.Length;
        count = count_1 + count_2;

        if(!(visibility.x >= 0 && 1 >= visibility.x && visibility.y >= 0 && 1 >= visibility.y) && count < 15 && Time.time > canSpawn) {
            canSpawn = Time.time + SpawnRate;
            if (count_1 < 10) {
                GameObject.Instantiate(enemy[0], transform.position, transform.rotation);
            } else if (count_2 < 5) {
                GameObject.Instantiate(enemy[1], transform.position, transform.rotation);
            }
            
        }
    }
}
