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

	public new static ShooterGameInstance Game()
	{
		return _ShooterGame;
	}

	public static bool IsPaused()
	{
		if (_ShooterGame == null) return false;
		return _ShooterGame.Paused;
	}
}
