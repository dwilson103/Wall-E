using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public static bool inConversation = false;
	private static int currentDialogueLine;
	private static int numberOfDialogueLines;
	private static List<string> dialogueList;

	private static Text textTitle;
	private static Text textBody;
	private static Text textContinue;

	private static string DIALOGUE_COMMAND_TEMPLATE = "SMROB926$ >> cpm run interpretDialogue -source \"{0}\" \n ...Dialogue System engaged, incoming communication";
	private static string DIALOGUE_MANUAL_SKIP = "Press RETURN to terminate dialogue entry";
	private static string DIALOGUE_COUNTDOWN_TEMPLATE = "Terminating dialogue in {0:f2}...";
	private static string OBJECT_SCAN_TITLE = "SMROB926$ >> cpm run scanObject \n ...Object found! Processing information";
	private static string OBJECT_INFORMATION_TEMPLATE = "Object Name: \"{0}\"\n >>> {1}";
	private static string HM_PICKUP_TITLE = "SMROB926$ >> cpm run loadHiddenMachine -source \"{0}\" --help \n ...HM successfully installed!";

	public float textPersist;
	private float textTimer;

	// Use this for initialization
	void Start () {
		textTitle = GameObject.Find("Title").GetComponent<Text>();
		textBody = GameObject.Find("Body").GetComponent<Text>();
		textContinue = GameObject.Find("Continue").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		bool textIsEmpty = textBody.text == "";

		if(!textIsEmpty){
			if(!inConversation) {
				SetAndDisplayCountdown(textIsEmpty);
			} else {
				textContinue.text = DIALOGUE_MANUAL_SKIP;
				if(Input.GetKeyDown(KeyCode.Return)) {
					if(numberOfDialogueLines > 0) {
						DisplayNextLine();
					} else {
						textBody.text = "";
						inConversation = false;
					}
				}
			}
		}
		
		SetTextBoxActive(!textIsEmpty);
		
	}

	void SetTextBoxActive(bool isActive) {
		foreach(Transform child in transform) {
			child.gameObject.SetActive(isActive);
		}
	}

	private void SetAndDisplayCountdown(bool textIsEmpty) {
		if(!textIsEmpty && textTimer <= 0) {
			textTimer = textPersist;
		} else if(!textIsEmpty && textTimer > 0) {
			textContinue.text = String.Format(DIALOGUE_COUNTDOWN_TEMPLATE,
									textTimer);
			textTimer -= Time.deltaTime;
			if(textTimer <= 0) {
				textBody.text = "";
			}
		} 
	}

	private static void DisplayNextLine() {
		Debug.Log(currentDialogueLine + " || " + numberOfDialogueLines);
		if(currentDialogueLine < numberOfDialogueLines) {
			textBody.text = dialogueList[currentDialogueLine];
			currentDialogueLine++;
		} else {
			textBody.text = "";
			inConversation = false;
			numberOfDialogueLines = 0;
		}
	}

	public static void DisplayNPCText(string NPCName, string dialogue) {
		inConversation = true;

		textTitle.text = String.Format(DIALOGUE_COMMAND_TEMPLATE,
                         	NPCName);
		textBody.text = dialogue;
	}

	// Override for multi-line dialogue
	public static void DisplayNPCText(string NPCName, List<string> dialogue) {
		inConversation = true;
		numberOfDialogueLines = dialogue.Count;
		currentDialogueLine = 0;
		dialogueList = dialogue;

		textTitle.text = String.Format(DIALOGUE_COMMAND_TEMPLATE,
                         	NPCName);

		DisplayNextLine();
	}

	public static void DisplayInfoText(string objectName, string infoText) {
		inConversation = true;

		textTitle.text = OBJECT_SCAN_TITLE;
		textBody.text = String.Format(OBJECT_INFORMATION_TEMPLATE,
							objectName, infoText);
	}

	public static void DisplayHMText(string HMName, string HMText) {
		inConversation = true;

		textTitle.text = String.Format(HM_PICKUP_TITLE,
							HMName);
		textBody.text = HMText;	
	}
}
