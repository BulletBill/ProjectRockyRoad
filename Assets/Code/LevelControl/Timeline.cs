using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Timeline : MonoBehaviour {

	//End time of the level timeline
	public float maxTime;
	public float currentTime = 0;

	//Set in editor
	public List<TimedSpawn> spawns;
	//public List<GameObject> environment;

	// Use this for initialization
	void Start () {
		if (spawns.Count > 0) {
			for (int i = 0; i < spawns.Count; i++) {
				spawns[i].used = false;
			}
		}	
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTime < maxTime) {
			currentTime += Time.deltaTime;
		}
	}

	void OnDrawGizmos() {
		//Draw the actual line
		Gizmos.color = Color.yellow;
		float widthOfLine = Screen.width / 100 / 3;

		Vector3 startOfLine = new Vector3(this.transform.position.x - widthOfLine, this.transform.position.y, 0);
		Vector3 endOfLine = new Vector3(this.transform.position.x + widthOfLine, this.transform.position.y, 0);
		Gizmos.DrawLine(startOfLine, endOfLine);

		//Draw the tracker
		float trackerPositionX = (currentTime / maxTime) * (widthOfLine * 2);
		Gizmos.DrawLine(startOfLine + new Vector3(trackerPositionX, -0.1f, 0), startOfLine + new Vector3(trackerPositionX, 0.1f, 0));

		//Draw spawn points
		Gizmos.color = Color.red;
		if (spawns.Count > 0) {
			foreach (TimedSpawn e in spawns) {
				trackerPositionX = (e.spawnTime / maxTime) * (widthOfLine * 2);
				Gizmos.DrawSphere(startOfLine + new Vector3(trackerPositionX, -0.15f, 0), 0.1f);
			}
		}

		//Draw environment points
	}

}
