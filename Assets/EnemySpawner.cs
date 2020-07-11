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
    [SerializeField] GameObject enemy;

    private GameObject[] getCount;
    int count;

    private void Start() {
        centre = GameObject.Find("Control").transform.position;
    }

    private void Update() {
        angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(angle), Mathf.Cos(angle)) * Radius;
        transform.position = centre + offset;

        visibility = Camera.main.WorldToViewportPoint(new Vector2(transform.position.x, transform.position.y));

        getCount = GameObject.FindGameObjectsWithTag("Enemy");
        count = getCount.Length;

        if(!(visibility.x >= 0 && 1 >= visibility.x && visibility.y >= 0 && 1 >= visibility.y) && count < 10) {
            GameObject.Instantiate(enemy, transform.position, transform.rotation);
        }
    }
}
