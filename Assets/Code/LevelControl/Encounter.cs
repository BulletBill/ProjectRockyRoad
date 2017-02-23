using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Encounter : MonoBehaviour {

	//List of spawns for this encounter
	public List<EnemySpawner> Spawns;

	//List of enemies that are still alive.
	List<GameObject> LivingEnemies;

	//Rate of speed for spawning enemies
	float SpeedMultiplier = 1.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
