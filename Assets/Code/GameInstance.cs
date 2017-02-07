using UnityEngine;
using System.Collections;

public class GameInstance : MonoBehaviour {

	public static GameInstance Game { get; protected set; }

	// Use this for initialization
	void Start() {
		if (Game == null) {
			Game = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			GameObject.Destroy(this.gameObject);
		}
	}
}
