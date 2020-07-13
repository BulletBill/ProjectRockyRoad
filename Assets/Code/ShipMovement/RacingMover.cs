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
        Vector3 MoveSpeed = new Vector3(0, Speed, 0);
        transform.Translate(transform.up * (Speed * Time.deltaTime), Space.World);

        if (PauseMovement) return;
        transform.Rotate(new Vector3(0, 0, -TurnSpeed) * Time.deltaTime * Input.GetAxis("Horizontal"));
        MoveDirection = transform.rotation;

        float Accel = Input.GetAxis("Vertical");
        Speed = Mathf.Clamp(Speed + Accel, -TopSpeed, TopSpeed);
    }
}
