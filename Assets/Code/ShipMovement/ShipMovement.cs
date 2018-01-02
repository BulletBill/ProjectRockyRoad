using UnityEngine;
using System.Collections;

[System.Serializable]
public class ShipMovementStats {

	[Range(0.0f, 1.0f)]
    public float acceleration;
	[Range(0.0f, 1.0f)]
	public float deceleration;
	public float topSpeed;
	public float turnSpeed;
	public float forwardMultiplier = 1.0f;

	public ShipMovementStats() {
	}

	public ShipMovementStats(float Speed, float Accel, float Decel, float Turn, float ForwardMultiplier) {
		topSpeed = Speed;
		acceleration = Accel;
		deceleration = Decel;
		turnSpeed = Turn;
		forwardMultiplier = ForwardMultiplier;
    }
}