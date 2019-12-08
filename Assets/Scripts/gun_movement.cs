using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun_movement : MonoBehaviour {

    public float speed = 5.0f;
    bool up = false;
    public Pool p;

	void Start () {
        transform.position = new Vector2(10.6f, 0.0f);
        p = GameObject.FindGameObjectWithTag("Enemy").GetComponent<Pool>();
        InvokeRepeating("Spawner", 0.1f, 0.5f);
	}
	
	void Update () {
        if (!up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - speed * Time.deltaTime);
            if (transform.position.y < -3.0f)
                up = true;
        }
        else if (up)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + speed * Time.deltaTime);
            if (transform.position.y > 4.0f)
                up = false;
        };
    }

    void Spawner()
    {
        p.Spawn();
    }
}
