﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float movex;
    private float movey;
    public float moveSpeed;
	public float startAngVelocity;

    public Rigidbody2D rb;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate () {
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        //transform.Translate(0, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0);

        movex = Input.GetAxis("Horizontal");
        movey = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(movex * moveSpeed, movey * moveSpeed);


//		startAngVelocity = rb.angularVelocity;
//		if (startAngVelocity > 0)
//		{
//			rb.angularVelocity = (startAngVelocity - 100f);
//		}
//		if (startAngVelocity < 0)
//		{
//			rb.angularVelocity = (startAngVelocity + 100f);
//		}
    }
}
