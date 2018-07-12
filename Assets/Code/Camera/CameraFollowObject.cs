using UnityEngine;
using System.Collections;

public class CameraFollowObject : MonoBehaviour {
	public Transform FollowObject;

	public Vector2 Margin;
	public float Smoothing;

	public void Start() {
	}

	public void Update() {
		var x = transform.position.x;
		var y = transform.position.y;

		//Move camera to player if following
		if (FollowObject != null) {
			if (Smoothing > 0.0f) {
				if (Mathf.Abs(x - FollowObject.position.x) > Margin.x) {
					x = Mathf.Lerp(x, FollowObject.position.x, Smoothing * Time.deltaTime);
				}
				if (Mathf.Abs(y - FollowObject.position.y) > Margin.y) {
					y = Mathf.Lerp(y, FollowObject.position.y, Smoothing * Time.deltaTime);
				}
			} else {
				x = FollowObject.position.x;
				y = FollowObject.position.y;
			}

			transform.position = new Vector3(x, y, transform.position.z);
		}
	}

}

