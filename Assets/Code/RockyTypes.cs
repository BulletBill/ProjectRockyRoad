using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockyTypes : MonoBehaviour {

	public enum InputAxis { Horizontal, Vertical, Thrust, Fire1, Fire2, Fire3, Fire4, Fire5, Item1, Item2, Item3, Item4, Item5, MaxAxis}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

public interface iInputReceiver {
	void SetAxis(RockyTypes.InputAxis AxisName, float Value);
	float GiveCommand(string Command, float Value);
}