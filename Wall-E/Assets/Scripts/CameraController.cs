using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	private static bool cameraExists;
	private static bool UIExists;

	// Use this for initialization
	void Start () {
		
		offset = transform.position - player.transform.position;

		if(!cameraExists) {
			cameraExists = true;
			DontDestroyOnLoad(transform.gameObject);
		}
		else {
			Destroy(gameObject);
		}

		if(!UIExists) {
			SceneManager.LoadScene("UIScene", LoadSceneMode.Additive);
			UIExists = true;
		} 
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
