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
	iInputReceiver FocusObject;
	
	// Use this for initialization
	void Start () {
		if (null == FocusObject) {
			GameObject.FindGameObjectWithTag("player");
		}
	}
	
	// Update is called once per frame
	void Update () {
		//Handle and pass input
		if (null != FocusObject) {

			FocusObject.SetAxis(RockyTypes.InputAxis.Horizontal, Input.GetAxis("Horizontal"));
			FocusObject.SetAxis(RockyTypes.InputAxis.Fire1, Input.GetAxis("Fire1"));
		}
	}
}
