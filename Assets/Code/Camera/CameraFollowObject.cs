using UnityEngine;
using System.Collections;

public class CameraFollowObject : MonoBehaviour {
	public Transform FollowObject;

	public Vector2 Margin;
	public Vector2 Smoothing;

	public void Start() {
	}

	public void Update() {
		var x = transform.position.x;
		var y = transform.position.y;

		//Move camera to player if following
		if (FollowObject != null) {
			if (Mathf.Abs(x - FollowObject.position.x) > Margin.x) {
				x = Mathf.Lerp(x, FollowObject.position.x, Smoothing.x * Time.deltaTime);
			}
			if (Mathf.Abs(y - FollowObject.position.y) > Margin.y) {
				y = Mathf.Lerp(y, FollowObject.position.y, Smoothing.y * Time.deltaTime);
			}

			transform.position = new Vector3(x, y, transform.position.z);
		}
	}

}

