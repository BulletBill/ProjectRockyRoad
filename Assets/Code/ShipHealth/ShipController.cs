using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour, iShipInitializer {

	// Ship combat stats
	float DamageMultiplier;

	public float CurrentInternalHealth;
	float MaxInternalHealth;

	public List<string> SectionStrings;

	// Ship movement stats
	public float TotalMass; // Totaled from all sections and components

	public float EnergyMaximum;
	public float EnergyCurrent;
	public float EnergyPerSec;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void InitShip() {
		foreach (string str in SectionStrings) {
			// Grab and attach sections (GameObjects) that match the strings, then init those
		}
	}
}
