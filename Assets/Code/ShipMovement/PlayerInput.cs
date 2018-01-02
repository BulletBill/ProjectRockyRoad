using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {

	ShipMover mover;
	WeaponCollective weapons;

	// Use this for initialization
	void Start () {
		mover = gameObject.GetComponent<ShipMover>();
		weapons = gameObject.GetComponent<WeaponCollective>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxisRaw("Horizontal") < 0) {
			mover.MoveLeft();
		}
		if (Input.GetAxisRaw("Horizontal") > 0) {
			mover.MoveRight();
		}
		if (Input.GetAxisRaw("Vertical") < 0) {
			mover.MoveDown();
		}
		if (Input.GetAxisRaw("Vertical") > 0) {
			mover.MoveUp();
		}
		if (Input.GetAxis("Fire1") != 0 && weapons != null) {
			weapons.FireWeaponGroup(1);
		}
		if (Input.GetAxis("Fire2") != 0 && weapons != null) {
			mover.MoveToFacing();
		}

		//Look at mouse position
		mover.FacePoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
	}
}
