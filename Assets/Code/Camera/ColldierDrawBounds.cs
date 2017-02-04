using UnityEngine;
using System.Collections;

public class ColldierDrawBounds : MonoBehaviour {

	public bool ShowBoxCollider = true;
	public bool ShowEdgeCollider = true;

	void OnDrawGizmos() {
		EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
		BoxCollider2D box = GetComponent<BoxCollider2D>();

		// Draw EdgeColliders
		if (edge != null && ShowEdgeCollider) {
			int i = 0;
			foreach(Vector2 v in edge.points){
				if (i != edge.points.Length - 1) {  
					Vector3 start = new Vector3(v.x + transform.position.x, v.y + transform.position.y, 0f);
					Vector3 end = new Vector3(edge.points[i+1].x + transform.position.x, edge.points[i+1].y + transform.position.y, 0f);
					Gizmos.color = Color.yellow;
					Gizmos.DrawLine (start, end);
					i++;
				}
			}
		}

		// Draw BoxColliders
		if (box != null && ShowBoxCollider) { 
			float offsetX = box.offset.x;
			float offsetY = box.offset.y;

			Vector3 tl = new Vector3(transform.position.x - (box.size.x / 2) + offsetX, transform.position.y + (box.size.y / 2) + offsetY, 0f + offsetX);
			Vector3 bl = new Vector3(transform.position.x - (box.size.x / 2) + offsetX, transform.position.y - (box.size.y / 2) + offsetY, 0f + offsetX);
			Vector3 br = new Vector3(transform.position.x + (box.size.x / 2) + offsetX, transform.position.y - (box.size.y / 2) + offsetY, 0f + offsetX);
			Vector3 tr = new Vector3(transform.position.x + (box.size.x / 2) + offsetX, transform.position.y + (box.size.y / 2) + offsetY, 0f + offsetX);
			Gizmos.color = Color.green;
			Gizmos.DrawLine (tl, bl);
			Gizmos.DrawLine (bl, br);
			Gizmos.DrawLine (br, tr);
			Gizmos.DrawLine (tr, tl);
		}
	}

}
