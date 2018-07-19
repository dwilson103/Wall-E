using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {

	public static List<string> playerAbilities = new List<string>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public static bool PlayerHasAbility(string abilityName) {
		return playerAbilities.Contains(abilityName);
	}

	public static void AddNewAbility(string abilityName) {
		playerAbilities.Add(abilityName);
	}
}
