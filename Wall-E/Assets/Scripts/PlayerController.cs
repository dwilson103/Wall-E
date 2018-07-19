using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float X_input;
	private float Y_input;

	public float player_speed;

	private Rigidbody2D player_rigid_body;

	private Animator player_animator;
	private AudioSource player_audio;

	private float dashCooldown;
	private float dashCountdown;
	private Vector2 dashVector;
	public float dashTime;
	public float dashMultiplier;
	
	private static bool playerExists;

	// Use this for initialization
	void Start () {
		player_rigid_body = GetComponent<Rigidbody2D>();
		player_animator = GetComponent<Animator>();
		player_audio = GetComponent<AudioSource>();

		if(!playerExists) {
			playerExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else {
			Destroy(gameObject);
		}
	}

	
	// Update is called once per frame
	void Update () {
		MovePlayer();
		PlayerDash();
	}

	void OnCollisionEnter2D(Collision2D col) {
		PlayCollisionSound();
	}

	public void PlayCollisionSound() {
		player_audio.volume = 0.4f;
		player_audio.Play();
	}

	public void PlayCollisionSound(AudioClip bumpClip) {
		player_audio.volume = 0.4f;
		player_audio.PlayOneShot(bumpClip);
	}

	private void MovePlayer() {
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

		if (dashCountdown > 0) {
			
		}

		PlayerDash();

		Vector2 movementVector = dashCountdown > 0
			? dashVector
			: new Vector2(X_input, Y_input);

		player_rigid_body.velocity = movementVector * player_speed;
	}

	private void PlayerDash() {

		if(Input.GetKeyDown(KeyCode.F) && dashCountdown <= 0 && dashCooldown <= 0) {
			dashCountdown = dashTime;
			dashVector = new Vector2(player_animator.GetFloat("X_input"), player_animator.GetFloat("Y_input")) * dashMultiplier;
		} else if ( dashCountdown >=0 ) {
			dashCountdown -= Time.deltaTime;
			if (dashCountdown <= 0) dashCooldown = dashTime * 3f;
		} else {
			dashCooldown -= Time.deltaTime;
		}
	}

	public bool GetPlayerDashState() {
		return dashCountdown > 0;
	}

	public void CancelDash() {
		dashCountdown = 0f;
		dashCooldown = dashTime * 3f;
	}
}
