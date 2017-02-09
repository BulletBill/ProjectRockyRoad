using UnityEngine;
using System.Collections;

public class GameInstance : MonoBehaviour {

	//Game instance singleton
	public static GameInstance Game { get; protected set; }

	//State of the player's current run
	public PlayerInstance Player;

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
