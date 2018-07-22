using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scanner : MonoBehaviour {

    public float interactionRange;

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

		Physics2D.queriesStartInColliders = false;

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
            interactionRange);

        GameObject resultObj = result.collider.gameObject;

        switch (resultObj.tag) {
            case "HM":
                HMInteraction(resultObj);
                break;
            case "NPC":
                NPCInteraction(resultObj);
                break;
            case "Interactable":
                ObjectInteraction(resultObj);
                break;
            default:
                Debug.Log("No Interaction for this object");
                break;
        } 
        
       
        Debug.Log("Scanner result: " + result.collider);
    }

    private void HMInteraction(GameObject HMObj) {
        InteractableObject HMInfo = HMObj.GetComponent<InteractableObject>();

        string HMName = HMInfo.objectName;
        string HMText = HMInfo.infoText;

        TextController.DisplayHMText(HMName, HMText);

        PlayerStatus.AddNewAbility(HMObj.name);
        GameObject.Destroy(HMObj);
    }

    private void NPCInteraction(GameObject NPCObj) {
        List<string> dialogue = new List<string>();

        dialogue.Add("Hello I am Crow #1");
        dialogue.Add("CAAAWWWWWWWWWWW [I am crow number 2]");

        TextController.DisplayNPCText("Crow", dialogue);
    }

    private void ObjectInteraction(GameObject envObj) {
        InteractableObject objInteractionInfo = envObj.GetComponent<InteractableObject>();

        string infoText = objInteractionInfo.infoText;
        string objectName = objInteractionInfo.objectName;

        TextController.DisplayInfoText(objectName, infoText);
    }
}