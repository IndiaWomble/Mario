using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_end : MonoBehaviour {

    int count = 0;
    int score = 0;
    public Text scoreText;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            score += 10;
            count++;
        }
    }

    private void Update()
    {
        scoreText.text = "Score : " + score;
        if (count >= 10)
            Application.Quit();
    }
}
