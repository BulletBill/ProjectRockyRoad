using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Encounter : MonoBehaviour {

	//List of spawns for this encounter
	public List<EnemySpawner> Spawns;

	//List of enemies that are still alive.
	List<GameObject> LivingEnemies;

	//Rate of speed for spawning enemies
	public float SpeedMultiplier = 0.5f;

	// Use this for initialization
	void Start () {
		foreach (EnemySpawner ES in GetComponentsInChildren<EnemySpawner>()) {
			Spawns.Add(ES);
		}
	}
	
	// Update is called once per frame
	void Update () {
		foreach (EnemySpawner ES in Spawns) {
			if (ES.isSpawning == false && ES.transform.localPosition.x > 0.0f) {
				ES.transform.Translate(-SpeedMultiplier * Time.deltaTime, 0.0f, 0.0f);

				if (ES.transform.localPosition.x <= 0.0f) {
					ES.StartSpawning();
				}
			}
		}
	}
}
