using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistantGameObject : MonoBehaviour {

	// public bool persistChildren;
	private bool ObjExists;

	// Use this for initialization
	void Start () {
		Debug.Log(ObjExists);
		if(!ObjExists) {
			ObjExists = true;
			DontDestroyOnLoad(gameObject);
			// if(persistChildren) {
			// 	foreach(Transform child in transform) {
			// 		DontDestroyOnLoad(child.gameObject);
			// 	}
			// }
		}
		else {
			Debug.Log("destroyed?");
			// Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
