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
    [SerializeField] int SpawnAmount = 15;
    [SerializeField] int EnemyOneAmount = 10;
    [SerializeField] int EnemyTwoAmount = 5;
    private float canSpawn = -1f;

    private GameObject[] getCount_1;
    private GameObject[] getCount_2;
    int count;
    int count_1;
    int count_2;

    private void Update() {
        centre = GameObject.Find("Control").transform.position;

        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;

        visibility = Camera.main.WorldToViewportPoint(new Vector2(transform.position.x, transform.position.y));

        getCount_1 = GameObject.FindGameObjectsWithTag("EnemyType1");
        getCount_2 = GameObject.FindGameObjectsWithTag("EnemyType2");
        count_1 = getCount_1.Length;
        count_2 = getCount_2.Length;
        count = count_1 + count_2;

        if(!(visibility.x >= 0 && 1 >= visibility.x && visibility.y >= 0 && 1 >= visibility.y) && count < SpawnAmount && Time.time > canSpawn) {
            canSpawn = Time.time + SpawnRate;
            if (count_1 < EnemyOneAmount) {
                GameObject.Instantiate(enemy[0], transform.position, transform.rotation);
            } else if (count_2 < EnemyTwoAmount) {
                GameObject.Instantiate(enemy[1], transform.position, transform.rotation);
            }
            
        }
    }
}
