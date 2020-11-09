using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterGameInstance : GameInstance
{
	public GameObject PlayerShip;
	public int Lives;
	public int Score;

	protected override void Start()
	{
		base.Start();
	}
}
