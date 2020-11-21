using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlayerMovement : MonoBehaviour
{
    public float VertSpeed;
    public float HorzSpeed;
    public float AccelTime;

    public Vector3 CurrentSpeed = new Vector3(0, 0, 0);
    public Vector2 Acceleration;

    public Rect MoveBounds = new Rect();

    public Vector2 MoveInput = new Vector2(0, 0);

    // Start is called before the first frame update
    void Start()
    {
        RecalculateAcceleration();
    }

    // Update is called once per frame
    void Update()
    {
        if (ShooterGameInstance.IsPaused()) { return; }
        GatherInput();
        ApplyAcceleration();
        ApplyMovement();
    }

    void GatherInput()
    {
        MoveInput.x = Math.Sign(Input.GetAxisRaw("Horizontal"));
        MoveInput.y = Math.Sign(Input.GetAxisRaw("Vertical"));
    }

    void ApplyAcceleration()
    {
        Vector2 Deltas = new Vector2(Acceleration.x, Acceleration.y);
        Vector2 Signs = new Vector2(Math.Sign(CurrentSpeed.x), Math.Sign(CurrentSpeed.y));

        if (MoveInput.x == 0)
        {
            CurrentSpeed.x -= Deltas.x * Signs.x * Time.deltaTime;
            if (Math.Sign(CurrentSpeed.x) != Signs.x)
            {
                CurrentSpeed.x = 0;
            }
        }
        else
        {
            CurrentSpeed.x = Mathf.Clamp(CurrentSpeed.x + (Deltas.x * MoveInput.x * Time.deltaTime), -HorzSpeed, HorzSpeed);
        }

        if (MoveInput.y == 0)
        {
            CurrentSpeed.y -= Deltas.y * Signs.y * Time.deltaTime;
            if (Math.Sign(CurrentSpeed.y) != Signs.y)
            {
                CurrentSpeed.y = 0;
            }
        }
        else
        {
            CurrentSpeed.y = Mathf.Clamp(CurrentSpeed.y + (Deltas.y * MoveInput.y * Time.deltaTime), -VertSpeed, VertSpeed);
        }
    }

    void ApplyMovement()
    {
        Vector3 NewPos = transform.position + (CurrentSpeed * Time.deltaTime);
        NewPos.x = Mathf.Clamp(NewPos.x, MoveBounds.x, MoveBounds.x + MoveBounds.width);
        NewPos.y = Mathf.Clamp(NewPos.y, MoveBounds.y, MoveBounds.y + MoveBounds.height);
        transform.position = NewPos;
    }

    void RecalculateAcceleration()
    {
		Acceleration.x = AccelTime > 0.0f ? VertSpeed / AccelTime : VertSpeed;
		Acceleration.y = AccelTime > 0.0f ? HorzSpeed / AccelTime : HorzSpeed;
	}
}
