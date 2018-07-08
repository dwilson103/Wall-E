using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerController : MonoBehaviour {
	public GameObject player;

	private const string SORTING_LAYER_BACKGROUND = "Environment";
	private const string SORTING_LAYER_FOREGROUND = "Foreground";
	private const int SORTING_ORDER = 1;

	private SpriteRenderer objectSprite;

	private Vector3 playerPosition;
	private Vector3 objectPosition;

	void Start() {
		objectSprite = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update () {
		playerPosition = player.transform.position;
		objectPosition = transform.position;

		DynamicLayerer();
	}

	void DynamicLayerer() {
		if(playerPosition.y > objectPosition.y) {
			objectSprite.sortingLayerName = SORTING_LAYER_FOREGROUND;
		} else {
			objectSprite.sortingLayerName = SORTING_LAYER_BACKGROUND;
		}
			objectSprite.sortingOrder = SORTING_ORDER;
	}
}
