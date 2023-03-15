using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class annoyingOrange : MonoBehaviour {
    public GameObject orange, finish; 
    public float spawnDelay = 0f, spawnRadius = 5f, spawnTimer = 0f;

    void Update() {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay && !finish.activeSelf) {
            spawnTimer = 0f;
            spawnDelay = 8f;
            Vector3 screenPos = new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), 0f);
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
            worldPos.z = 0f;
            GameObject newOrange = Instantiate(orange, worldPos, Quaternion.identity);
            newOrange.tag = "spawnedfood";
        }
    }
}
