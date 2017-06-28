using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float movex;
    private float movey;
    public float moveSpeed;

    public Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        //transform.Translate(0, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0);

        movex = Input.GetAxis("Horizontal_L");
        movey = Input.GetAxis("Vertical_L");

        rb.velocity = new Vector2(movex * moveSpeed, movey * moveSpeed);
		rb.angularVelocity = 0;

    }
}
