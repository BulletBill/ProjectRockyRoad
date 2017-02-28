using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Encounter : MonoBehaviour {

	//List of spawns for this encounter
	public List<EnemySpawner> Spawns;

	//List of enemies that are still alive.
	List<GameObject> LivingEnemies;

	//Rate of speed for spawning enemies
	public float SpeedMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
		foreach (EnemySpawner ES in GetComponentsInChildren<EnemySpawner>()) {
			Spawns.Add(ES);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (EnemySpawner ES in Spawns) {

		}
	}
}
