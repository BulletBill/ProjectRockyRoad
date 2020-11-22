 using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class path : MonoBehaviour {

	//Worldspace coords
	public Vector2 Origin;

	//Array of Path nodes
	public List<pathNode> waypoints = new List<pathNode>();

	// Use this for initialization
	void Start () {
        foreach (pathNode p in waypoints) {
            p.align(Origin);
        }
    }

    // Update is called once per frame
    void Update () {
	
    }

	public Vector2 GetNodePos(int NodeIndex) {
		Vector2 Ret = Origin;
		if (NodeIndex < waypoints.Count) {
			Ret += new Vector2(waypoints[NodeIndex].relx, waypoints[NodeIndex].rely);
		}

		return Ret;
	}

    public void OnDrawGizmosSelected() {
		Gizmos.color = Color.magenta;
		Gizmos.DrawSphere(transform.position, 0.05f);
		Vector3 directionPoint = Quaternion.AngleAxis(transform.eulerAngles.z, Vector3.forward) * Vector3.up;
		Gizmos.DrawLine(transform.position, transform.position + (directionPoint * 0.5f));

        if (waypoints.Count <= 0)
            return;

        for (int i = 0; i < waypoints.Count; i++) {
            Gizmos.color = i == 0 ? Color.red : Color.cyan;
            Vector3 currentPos = new Vector3(Origin.x + waypoints[i].relx, Origin.y + waypoints[i].rely);
            Gizmos.DrawSphere(currentPos, waypoints[i].radius);

			int NextNode = waypoints[i].NextNode;
			if (NextNode >= 0 && NextNode < waypoints.Count) {
				Gizmos.color = Color.yellow;
				Vector3 nextPos = new Vector3(Origin.x + waypoints[NextNode].relx, Origin.y + waypoints[NextNode].rely);
				Gizmos.DrawLine(currentPos, nextPos);
			}
        }
    }
}
