using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour {

	void Start() {
	}

	// Update is called once per frame
	void Update () {
		float offset = GetComponent<BoxCollider2D>() ? GetComponent<BoxCollider2D>().offset.y : 0;
		GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt((transform.position.y + offset)*100)*-1;
	}

}