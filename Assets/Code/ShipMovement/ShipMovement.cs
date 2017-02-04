using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShipMovementStats {

	public float speed;
	[Tooltip("Value between 0 and 100")]
	public float acceleration;
	[Tooltip("Value between 0 and 100")]
	public float deceleration;
	public float turnSpeed;

	public float currentSpeed { get; set; }

	public ShipMovementStats() {
	}

	public ShipMovementStats(float Speed, float Accel, float Decel, float Turn) {
		speed = Speed;
		acceleration = Accel;
		deceleration = Decel;
		turnSpeed = Turn;
	}
}