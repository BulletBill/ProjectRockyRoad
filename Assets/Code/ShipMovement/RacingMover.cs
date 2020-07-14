using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacingMover : MonoBehaviour
{
    bool PauseMovement = false;

	public float TurnSpeed;
	public float TopSpeed;
	public float Acceleration;

	float Speed;
    Quaternion MoveDirection;
    float Friction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (PauseMovement) return;

		// Update movement direction
		MoveDirection = transform.rotation;

        // Move ship based on speed
        float MoveAngle = Quaternion.Angle(MoveDirection, transform.rotation) + (90 * Mathf.Deg2Rad);
        Vector3 MoveDelta = new Vector3(Mathf.Cos(MoveAngle), Mathf.Sin(MoveAngle), 0.0f);
        transform.Translate(MoveDelta * (Speed * Time.deltaTime));

        // Apply input
        transform.Rotate(new Vector3(0, 0, -TurnSpeed) * Time.deltaTime * Input.GetAxis("Horizontal"));

        float Accel = Input.GetAxis("Vertical") * Time.deltaTime * Acceleration;
        Speed = Mathf.Clamp(Speed + Accel, -TopSpeed, TopSpeed);
    }
}
