using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour {

	void Start() {
	}

	// Update is called once per frame
	void Update () {
			GetComponent<SpriteRenderer>().sortingOrder = Mathf.RoundToInt((transform.position.y + GetComponent<BoxCollider2D>().offset.y)*100)*-1;
	}

}