using UnityEngine;
using System.Collections;

public class ShipComponentHealth : MonoBehaviour, IDamageable {
	
	//Public values should be set in editor
	public float maximumHealth;
	float health;

	public float fixedDamageReduction;
	[Tooltip("Value should be between 0 and 100")]
	public float percentDamageReduction;
	float pdr;

	[Tooltip("Seconds of invulnerability after being hit")]
	public float invulnerabilityAfterHit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public float Damage (float dmg) {
		return 0.0f;
	}
}
