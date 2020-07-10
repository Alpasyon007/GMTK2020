using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform player;
    /*[SerializeField] float negativeX, positiveX, negativeY, positiveY;*/

    [Range(0, 0.1f)] [SerializeField] float smoothing_factor = 0.2f;

    Vector3 camera_pos;
    public Vector2 camera_velocity;

    void Awake() {
        camera_pos = transform.position;
    }

    private void FixedUpdate() {
        Vector3 playerPos = new Vector3(player.position.x, player.position.y, -10);
        Vector3 SmoothedPos = Vector3.Lerp(transform.position, playerPos, smoothing_factor);
        /*SmoothedPos.x = Mathf.Clamp(SmoothedPos.x, negativeX, positiveX);
        SmoothedPos.y = Mathf.Clamp(SmoothedPos.y, negativeY, positiveY);*/
        transform.position =  SmoothedPos;

        camera_velocity = (transform.position - camera_pos) / Time.fixedDeltaTime;
        camera_pos = transform.position;
    }

    /*public void UpdateClamp(float new_negative_x, float new_positive_x, float new_negative_y, float new_positive_y) {
        negativeX = new_negative_x;
        positiveX = new_positive_x;
        negativeY = new_negative_y;
        positiveY = new_positive_y;
    }*/
}
