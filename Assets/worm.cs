using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class worm : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public GameObject gameOver, AHHH, polkaFace, cthulhu;
    public float verticalSpeed, horizontalSpeed, timeRemaining = 20f, vectTime = 2f;
    public int score = 0, level = 1, initialLevel = 1;
    public TextMeshProUGUI scoreText, levelText, textMesh, textLevelMesh;
    public AudioSource audioSource, audioBackgroundSource;
    void Start() {
        verticalSpeed = 6;
        horizontalSpeed = 6;
    }

    void Update() {
        timeRemaining -= Time.deltaTime;
        vectTime -= Time.deltaTime;

        if (vectTime <= 0) {
            Spawn();
            vectTime = 2f;  
        }

        if (timeRemaining <= 0) {
            if (level - initialLevel == 2) {
                initialLevel += 2;
            }
            score+= 5;
            level++;
            horizontalSpeed++;
            verticalSpeed++;
            timeRemaining = 20f;
        }

        scoreText.text = "Score: " + score.ToString();
        levelText.text = "Level " + level.ToString();
        textMesh.text = scoreText.text;
        textLevelMesh.text = levelText.text;

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            myRigidBody.velocity = Vector2.up * verticalSpeed;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            myRigidBody.velocity = Vector2.down * verticalSpeed;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            myRigidBody.velocity = Vector2.right * horizontalSpeed;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            myRigidBody.velocity = Vector2.left * horizontalSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "cthulhu" || col.gameObject.tag == "mainCthulhu" || col.gameObject.tag == "newVect") {
            Quaternion currentRotation = myRigidBody.transform.rotation;
            Quaternion newRotation = Quaternion.Euler(0f, 0f, currentRotation.eulerAngles.z + -90f);
            myRigidBody.transform.rotation = newRotation;
            gameOver.SetActive(true);
            audioSource = GetComponent<AudioSource>();
            audioBackgroundSource = GetComponent<AudioSource>();
            AHHH.SetActive(true);
            polkaFace.SetActive(false);
            timeRemaining = 100000000000000000;
            Destroy(myRigidBody);
            cthulhu.SetActive(false);
            Destroy(cthulhu);
        }
    }

    void Spawn() {
        float screenWidth = Screen.width;
        Vector2 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector2(Random.Range(0, screenWidth), 0));
        Instantiate(cthulhu, spawnPosition, Quaternion.identity);
    }
}

