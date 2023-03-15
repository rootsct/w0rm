using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public float moveSpeed = 2;
    private Transform player;
    private float timeRemaining = 0f;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0) {
            moveSpeed++;
            timeRemaining = 20f;
        }

        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
