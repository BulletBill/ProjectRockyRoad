using UnityEngine;
using System.Collections;

// Receives input from the Player Instance and passes it to the ship mover

public class PlayerShipInput : MonoBehaviour, iInputReceiver {

	ShipMover mover;
	WeaponCollective[] weapons;

	// Small ships will act as a turret
	public bool SelfTurret;

	// Use this for initialization
	void Start () {
		mover = gameObject.GetComponent<ShipMover>();
		weapons = gameObject.GetComponentsInChildren<WeaponCollective>();
	}
	
	// Update is called once per frame
	void Update () {
		//Look at mouse position
		if (SelfTurret) {
			mover.FacePoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
	}

	//Input reciever functions
	void iInputReceiver.ProcessInput() {
		float HorzInput = Input.GetAxis("Horizontal");
		if (HorzInput < 0.0f) mover.MoveLeft();
		if (HorzInput > 0.0f) mover.MoveRight();

		float VertInput = Input.GetAxis("Vertical");
		if (VertInput < 0.0f) mover.MoveDown();
		if (VertInput > 0.0f) mover.MoveUp();

		if (Input.GetAxis("Fire2") != 0.0f) mover.MoveToFacing();

		if (Input.GetAxis("Fire1") != 0.0f && weapons.Length > 0) {
			foreach (WeaponCollective wc in weapons) {
				wc.FireWeaponGroup(1);
			}
		}
	}

	float iInputReceiver.GiveCommand(string Command, float Value) {
		return 0.0f;
	}
}
