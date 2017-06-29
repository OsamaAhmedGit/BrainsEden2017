using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float movex;
    private float movey;
    public float moveSpeed;
	public float horR, verR;

    private Rigidbody2D rb;

	private Animator animator;

	void Start () {
        rb = GetComponent<Rigidbody2D>();

		animator = GetComponent<Animator> ();
	}
	
	void FixedUpdate () {
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0, 0);
        //transform.Translate(0, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime, 0);

        movex = Input.GetAxis("Horizontal_L");
        movey = Input.GetAxis("Vertical_L");

        rb.velocity = new Vector2(movex * moveSpeed, movey * moveSpeed);

		horR = Input.GetAxis ("Horizontal_R");
		verR = Input.GetAxis ("Vertical_R");

		if (Input.GetAxis ("Horizontal_L") < 0)
			animator.Play ("PlayerLeftAnimation");
		else if (Input.GetAxis ("Horizontal_L") > 0)
			animator.Play ("PlayerRightAnimation");
		else if (Input.GetAxis ("Vertical_L") < 0)
			animator.Play ("PlayerDownAnimation");
		else if (Input.GetAxis ("Vertical_L") > 0)
			animator.Play ("PlayerUpAnimation");

//		Vector2 lookVec = new Vector2 (Input.GetAxis("Horizontal_R"), Input.GetAxis("Vertical_R"));
//		transform.LookAt(transform.position.toVector2() + lookVec);

		Vector3 lookVec = new Vector3 (Input.GetAxis("Horizontal_R"), Input.GetAxis("Vertical_R"), 1f);
		transform.rotation = Quaternion.LookRotation(lookVec, Vector3.back);


    }
}
