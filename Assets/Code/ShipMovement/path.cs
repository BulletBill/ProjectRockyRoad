 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class path : MonoBehaviour {

    //Array of Path nodes
    public List<pathNode> waypoints;

    //Worldspace coords

	// Use this for initialization
	void Start () {
        foreach (pathNode p in waypoints) {
            p.align(transform.position);
        }
    }

    // Update is called once per frame
    void Update () {
	
    }

    public void OnDrawGizmosSelected() {
        if (waypoints.Count <= 0)
            return;

        for (int i = 0; i < waypoints.Count; i++) {
            Gizmos.color = i == 0 ? Color.red : Color.cyan;
            Vector3 currentPos = new Vector3(transform.position.x + waypoints[i].relx, transform.position.y + waypoints[i].rely);
            Gizmos.DrawSphere(currentPos, waypoints[i].radius);

			int NextNode = waypoints[i].NextNode;
			if (NextNode >= 0 && NextNode < waypoints.Count) {
				Gizmos.color = Color.yellow;
				Vector3 nextPos = new Vector3(transform.position.x + waypoints[NextNode].relx, transform.position.y + waypoints[NextNode].rely);
				Gizmos.DrawLine(currentPos, nextPos);
			}
        }
    }
}
