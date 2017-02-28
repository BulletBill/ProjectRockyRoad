using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    //Variables to be set in Editor
    public GameObject enemyToSpawn;
    public int spawnCount;
    public float spawnInterval;
    public path Path;

    float waitTime = 0.0f;

	public bool isSpawning { get; protected set; }

	// Use this for initialization
	void Start () {
		isSpawning = false;
    }
    // Update is called once per frame
	void Update () {
		if (isSpawning == false) { return; }
		
	    if (waitTime <= 0 && spawnCount > 0) {
            //Spawn Enemy
            waitTime = spawnInterval;
            spawnCount--;
            var spawned = Instantiate(enemyToSpawn, Path.Origin, Path.transform.rotation) as GameObject;
            spawned.GetComponent<AI_Pathfinder>().SetPath(Path);

			if (spawnCount <= 0) {
				FinishedSpawning();
			}
        }
        if (waitTime > 0) {
            waitTime -= Time.deltaTime;
        }
    }

	public void StartSpawning() {
		isSpawning = true;
	}

	public void FinishedSpawning() {
	}

	void OnDrawGizmosSelected() {
		if (Path) {
			Path.OnDrawGizmosSelected();
		}
	}
}
