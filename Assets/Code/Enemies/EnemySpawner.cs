using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

    //Variables to be set in Editor
    public GameObject enemyToSpawn;
    public int spawnCount;
    public float spawnInterval;
    public path defaultPath;

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
            var spawned = Instantiate(enemyToSpawn, this.transform.position, this.transform.rotation) as GameObject;
            spawned.GetComponent<AI_Pathfinder>().pathToFollow = defaultPath;
        }
        if (waitTime > 0) {
            waitTime -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(transform.position, 0.05f);
        Vector3 directionPoint = Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * Vector3.up;
        Gizmos.DrawLine(transform.position, transform.position + (directionPoint * 0.5f));
    }
}
