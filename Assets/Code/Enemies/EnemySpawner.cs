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

	// Use this for initialization
	void Start () {
	
    }
    // Update is called once per frame
	void Update () {
	    if (waitTime <= 0 && spawnCount > 0) {
            //Spawn Enemy
            waitTime = spawnInterval;
            spawnCount--;
            var spawned = Instantiate(enemyToSpawn, Path.transform.position, Path.transform.rotation) as GameObject;
            spawned.GetComponent<AI_Pathfinder>().pathToFollow = Path;
        }
        if (waitTime > 0) {
            waitTime -= Time.deltaTime;
        }
    }

	void OnDrawGizmosSelected() {
		if (Path) {
			Path.OnDrawGizmosSelected();
		}
	}
}
