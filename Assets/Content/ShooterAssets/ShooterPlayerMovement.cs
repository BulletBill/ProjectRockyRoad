using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlayerMovement : MonoBehaviour
{
    public float VertSpeed;
    public float HorzSpeed;
    public float AccelTime;

    public Rect MoveBounds = new Rect();

    float HorzInput = 0.0f;
    float VertInput = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ShooterGameInstance.IsPaused()) { return; }
        GatherInput();
    }

    void GatherInput()
    {
        HorzInput = Math.Sign(Input.GetAxis("Horizontal"));
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(new Vector3(MoveBounds.x, MoveBounds.y, 0.0f), new Vector3(MoveBounds.x + MoveBounds.width, MoveBounds.y, 0.0f));
        Gizmos.DrawLine(new Vector3(MoveBounds.x, MoveBounds.y, 0.0f), new Vector3(MoveBounds.x, MoveBounds.y + MoveBounds.height, 0.0f));
        Gizmos.DrawLine(new Vector3(MoveBounds.x, MoveBounds.y + MoveBounds.height, 0.0f), new Vector3(MoveBounds.x + MoveBounds.width, MoveBounds.y + MoveBounds.height, 0.0f));
        Gizmos.DrawLine(new Vector3(MoveBounds.x + MoveBounds.width, MoveBounds.y, 0.0f), new Vector3(MoveBounds.x + MoveBounds.width, MoveBounds.y + MoveBounds.height, 0.0f));
    }
}
