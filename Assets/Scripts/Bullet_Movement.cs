using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Movement : MonoBehaviour {

    bool player = true;
    public float speed = 15.0f;
    public Pool script;
    public Transform playerShootingPoint;
    public Transform enemyShootingPoint;

    void Start()
    {
        if (transform.position.x == enemyShootingPoint.position.x)
        {
            player = false;
            script = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Pool>();
        }
        else if (transform.position.x == playerShootingPoint.position.x)
        {
            script = GameObject.FindGameObjectWithTag("Player").GetComponent<Pool>();
            player = true;
        }
    }
	
	void Update () {
        if (player)
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        else if (!player)
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        script.BackToList(gameObject);
    }
}
