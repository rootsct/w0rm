using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newVect : MonoBehaviour {
    public float moveSpeed = 2;

    void Start() {

    }

    void Update() {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        Vector3 topEdge = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0f));
        if (transform.position.y >= topEdge.y & gameObject.name != "newVect") {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.CompareTag("spawnedfood")) {
            Destroy(col.gameObject);
        }
    }
}
