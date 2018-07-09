using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour {

    private Vector2 player_facing_direction = Vector2.zero;

    private Rigidbody2D player_rigid_body;
    private BoxCollider2D player_box_collider;
    

    // Use this for initialization
    void Start () {
        player_rigid_body = GetComponent<Rigidbody2D>();
        player_box_collider = GetComponent<BoxCollider2D>();
        player_facing_direction = new Vector2(0, -1);
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        Vector2 movement_vector = new Vector2(
            Input.GetAxisRaw("Horizontal"), 
            Input.GetAxisRaw("Vertical"));

        if (movement_vector != Vector2.zero) {
            player_facing_direction = movement_vector;
            player_facing_direction.Normalize();
        }

        if(Input.GetKeyDown(KeyCode.Space))
            UseScanner();
	}

    private void UseScanner()
    {
        RaycastHit2D result;

        result = Physics2D.Raycast(
            (Vector2)player_rigid_body.transform.position +
            player_box_collider.offset,
            player_facing_direction,
            Mathf.Infinity);
        
       
        Debug.Log("Scanner result: " + result.collider);
    }
}
