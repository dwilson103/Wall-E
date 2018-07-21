using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {

	public float parallaxFactor;

	private GameObject player;
	private float playerXPosition;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
		playerXPosition = player.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		float playerDifference = player.transform.position.x - playerXPosition;

		gameObject.transform.Translate(new Vector2(- playerDifference * parallaxFactor, 0));

		playerXPosition = player.transform.position.x;
	}
}
