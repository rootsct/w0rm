using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maincthulhu : MonoBehaviour
{
    public float moveSpeed = 0.6f;
    private Transform player;
    private float timeRemaining = 0f;

    void Start() {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update() {
        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0) {
            moveSpeed++;
            timeRemaining = 40f;
        }
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += moveSpeed * Time.deltaTime * direction;
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("spawnedfood")) {
            Destroy(col.gameObject);
        }
    }
}
