using UnityEngine;
using System.Collections;

public class ShipMover : MonoBehaviour {
	float visibleSpeed;

	//Holds values for movement. Can be set in editor
	public ShipMovementStats movementStats;

	//Input sockets
	Vector2 movementInput;

	//Dynamic movement stats
	Vector2 currentSpeed;

	// Use this for initialization
	void Start() {
		//Cache needed components
		Mathf.Clamp(movementStats.acceleration, 0, 100);
		Mathf.Clamp(movementStats.deceleration, 0, 100);
	}
	
	// Update is called once per frame
	void Update() {

		if (movementInput.x == 0 && movementInput.y == 0) {
			Decelerate();
		} else {
			Accelerate();
		}

		ApplyMovement();

		//Reset inputs
		movementInput.x = 0;
		movementInput.y = 0;
	}

	//Private functions
	void Decelerate() {
		currentSpeed *= 0.6f + ((1 - movementStats.deceleration) / 2.5f);
	}

	void Accelerate() {
		currentSpeed += (movementInput * (movementStats.speed * movementStats.acceleration));
	}

	void ApplyMovement() {
		//Clamp to max speed
		visibleSpeed = Mathf.Abs(currentSpeed.x) + Mathf.Abs(currentSpeed.y);

		if (Mathf.Abs(currentSpeed.x) + Mathf.Abs(currentSpeed.y) > movementStats.speed) {
			currentSpeed = currentSpeed.normalized * movementStats.speed;
		}

		this.transform.position += new Vector3(currentSpeed.x, currentSpeed.y, 0) * Time.deltaTime;
	}

	bool InputMatchesVelocity() {
		return true;
	}

	//These functions are called by an input handler or ai script to move the ship
	public void MoveUp() {
		movementInput.y += 1;
	}
	public void MoveDown() {
		movementInput.y -= 1;
	}
	public void MoveLeft() {
		movementInput.x -= 1;
	}
	public void MoveRight() {
		movementInput.x += 1;
	}
	public void MoveToFacing() {
		Vector2 dir = Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * Vector3.up;
		movementInput = dir.normalized;
	}
	public void MoveToPoint(Vector2 point) {
		Vector2 dir = new Vector2(point.x - transform.position.x, point.y - transform.position.y);
		movementInput = dir.normalized;
	}
	public void FacePoint (Vector3 facingTarget) {
		transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, facingTarget - transform.position), movementStats.turnSpeed * Time.deltaTime);
	}
}
