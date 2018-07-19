using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour {

	private PlayerController playerController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D col) {

		string colTag = col.gameObject.tag;

		if(colTag == "Player"){
			GameObject player = col.gameObject;

			playerController = player.GetComponent<PlayerController>();
			Debug.Log(playerController.GetPlayerDashState());

			if(playerController.GetPlayerDashState()) {
				GameObject.Destroy(gameObject);
				playerController.CancelDash();
			}

		}
	}
}
