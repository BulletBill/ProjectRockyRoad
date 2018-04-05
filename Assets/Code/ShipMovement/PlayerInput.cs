using UnityEngine;
using System.Collections;

// Receives input from the Player Instance and passes it to the ship mover

public class PlayerInput : MonoBehaviour, iInputReceiver {

	ShipMover mover;
	WeaponCollective weapons;

	// Small ships will act as a turret
	public bool SelfTurret;

	// Use this for initialization
	void Start () {
		mover = gameObject.GetComponent<ShipMover>();
		weapons = gameObject.GetComponent<WeaponCollective>();
	}
	
	// Update is called once per frame
	void Update () {
		//Look at mouse position
		if (SelfTurret) {
			mover.FacePoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
		}
	}

	//Input reciever functions
	void iInputReceiver.SetAxis(RockyTypes.InputAxis AxisName, float Value) {
		switch(AxisName) {
			case RockyTypes.InputAxis.Horizontal:
				if (null == mover) break;
				if (Value < 0.0f) mover.MoveLeft();
				if (Value > 0.0f) mover.MoveRight();
				break;

			case RockyTypes.InputAxis.Vertical:
				if (null == mover) break;
				if (Value < 0.0f) mover.MoveDown();
				if (Value > 0.0f) mover.MoveUp();
				break;

			case RockyTypes.InputAxis.Thrust:
				if (null == mover) break;
				mover.MoveToFacing();
				break;

			case RockyTypes.InputAxis.Fire1:
				if (null == weapons) break;
				weapons.FireWeaponGroup(1);
				break;

			 default:
				break;
		}
	}

	float iInputReceiver.GiveCommand(string Command, float Value) {
		return 0.0f;
	}
}
