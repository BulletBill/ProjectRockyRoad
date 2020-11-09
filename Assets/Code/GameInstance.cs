using UnityEngine;
using System.Collections;

public class GameInstance : MonoBehaviour {

	//Game instance singleton
	public static GameInstance Game { get; protected set; }

	// Use this for initialization
	protected virtual void Start() {
		if (Game == null) {
			Game = this;
			DontDestroyOnLoad(this.gameObject);
		} else {
			Object.Destroy(this.gameObject);
			return;
		}
	}
}
