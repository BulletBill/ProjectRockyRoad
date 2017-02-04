using UnityEngine;
using System.Collections;

public class CameraBounds : MonoBehaviour {

	public BoxCollider2D Bounds;
	private Vector3 _min;
	private Vector3 _max;

	private Camera myCamera;

	// Use this for initialization
	void Start () {
		_min = Bounds.bounds.min;
		_max = Bounds.bounds.max;

		myCamera = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Bounds != null) {
			var x = transform.position.x;
			var y = transform.position.y;

			//Clamp position based on bounds
			var cameraHalfWidth = myCamera.orthographicSize * ((float)Screen.width / Screen.height);
			x = Mathf.Clamp(x, _min.x + cameraHalfWidth, _max.x - cameraHalfWidth);
			y = Mathf.Clamp(y, _min.y + myCamera.orthographicSize, _max.y - myCamera.orthographicSize);

			transform.position = new Vector3(x, y, transform.position.z);
		}
	}
}
