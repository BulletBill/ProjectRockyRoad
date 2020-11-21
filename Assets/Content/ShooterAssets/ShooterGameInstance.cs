using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterGameInstance : GameInstance
{
	public static ShooterGameInstance _ShooterGame { get; protected set; }

	public bool Paused = false;
	public GameObject PlayerShip;
	public int Lives;
	public int Score;
	public float ScrollSpeed;
	public int GameSections;

	protected override void Start()
	{
		base.Start();

		if (_Game == this)
		{
			_ShooterGame = this;
		}
		else
		{
			Object.Destroy(this.gameObject);
			return;
		}
	}

	public static ShooterGameInstance Game()
	{
		return _ShooterGame;
	}

	public static bool IsPaused()
	{
		if (_ShooterGame == null) return false;
		return _ShooterGame.Paused;
	}

	public void OnDrawGizmos()
	{
		ShooterCamera cam = Camera.main.GetComponent<ShooterCamera>();
		Rect CameraRect = new Rect(cam.CameraPosition() - (cam.CameraSize() / 2.0f), cam.CameraSize());
		Gizmos.color = Color.red;
		DrawRect(CameraRect);
		for (int i = 0; i < GameSections; i++)
		{
			Rect Section = new Rect(CameraRect);
			float SectionSize = ScrollSpeed * 10.0f;
			Section.y += CameraRect.height + (i * SectionSize);
			Section.height = SectionSize;
			DrawRect(Section);
		}
	}

	public void DrawRect(Rect inRect)
	{
		Gizmos.DrawLine(new Vector3(inRect.x, inRect.y, 0.0f), new Vector3(inRect.x + inRect.width, inRect.y, 0.0f));
		Gizmos.DrawLine(new Vector3(inRect.x, inRect.y, 0.0f), new Vector3(inRect.x, inRect.y + inRect.height, 0.0f));
		Gizmos.DrawLine(new Vector3(inRect.x, inRect.y + inRect.height, 0.0f), new Vector3(inRect.x + inRect.width, inRect.y + inRect.height, 0.0f));
		Gizmos.DrawLine(new Vector3(inRect.x + inRect.width, inRect.y, 0.0f), new Vector3(inRect.x + inRect.width, inRect.y + inRect.height, 0.0f));
	}
}
