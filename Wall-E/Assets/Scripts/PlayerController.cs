using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float X_input;
	private float Y_input;

	public float player_speed;

	private Rigidbody2D player_rigid_body;

	private Animator player_animator;

	// Use this for initialization
	void Start () {
		player_rigid_body = GetComponent<Rigidbody2D>();
		player_animator = GetComponent<Animator>();
	}
	


	// Update is called once per frame
	void Update () {
		X_input = Input.GetAxisRaw("Horizontal");
		Y_input = Input.GetAxisRaw("Vertical");

				

		if((X_input != 0) || (Y_input != 0)) {
			player_animator.SetFloat("X_input",X_input);
			player_animator.SetFloat("Y_input",Y_input);
			player_animator.Play("MoveAnimation");
		}
		else {
			player_animator.Play("IdleAnimation");
		}


	
		player_rigid_body.velocity = new Vector2(X_input, Y_input)*player_speed;
	}

	
}
