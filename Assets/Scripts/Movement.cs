using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5.0f;
    public float jump = 4.0f;
    public LayerMask ground;
    bool isGrounded = true;
    public Transform feet_position;
    public float overlapRadius;
    public Pool p;

	void Start ()
    {
        transform.position = new Vector3(0.5f, -3.0f, 0.0f);
        p = GameObject.FindGameObjectWithTag("Player").GetComponent<Pool>();
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            p.Spawn();
        isGrounded = Physics2D.OverlapCircle(feet_position.position, overlapRadius, ground);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<SpriteRenderer>().flipX = true;
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<SpriteRenderer>().flipX = false;
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, jump));
    }
}
