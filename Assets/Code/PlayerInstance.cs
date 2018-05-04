using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Player Instance stores and loads the player's state data and progress
// It also distributes input to the correct receiver (ship, ui, or other)

public class PlayerInstance : MonoBehaviour {

	//List of items owned by the player
	public List<Item> Items;

	//Mission Progress and Records

	//Player stats / Current Build

	//Saved Designs

	//State Data
	public GameObject FocusObject;
	public iInputReceiver FocusReceiver;
	
	// Use this for initialization
	void Start () {
		if (null == FocusReceiver) {
			FocusObject = GameObject.FindGameObjectWithTag("Player");
			if (FocusObject) {
				FocusReceiver = FocusObject.GetComponent<iInputReceiver>();
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Handle and pass input
		if (null != FocusReceiver) {
			FocusReceiver.ProcessInput();
		}
	}
}
