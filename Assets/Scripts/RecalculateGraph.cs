using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecalculateGraph : MonoBehaviour
{
    void Update() {
        GameObject.Find("Player").GetComponent<GraphUpdateScene>().Apply();
    }
}
