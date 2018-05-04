using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyTypes : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public interface iInputReceiver {
	void ProcessInput();
	float GiveCommand(string Command, float Value);
}