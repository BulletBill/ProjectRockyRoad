using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShipMovementStats {

	public float speed;
	[Range(0.0f, 1.0f)]
    public float acceleration;
	[Range(0.0f, 1.0f)]
	public float deceleration;
	public float turnSpeed;

	public ShipMovementStats() {
	}

	public ShipMovementStats(float Speed, float Accel, float Decel, float Turn) {
		speed = Speed;
		acceleration = Accel;
		deceleration = Decel;
		turnSpeed = Turn;
	}
}