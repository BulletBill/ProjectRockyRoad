using UnityEngine;
using System.Collections;

[System.Serializable]
[RequireComponent(typeof(SpriteRenderer))]
public class ShipHealthSystem : MonoBehaviour {

	//Public values should be set in editor
	public float maximumHealth;
	float health;

	public float fixedDamageReduction;
	[Tooltip("Value should be between 0 and 100")]
	public float percentDamageReduction;
	float pdr;

	[Tooltip("Seconds of invulnerability after being hit")]
	public float invulnerabilityAfterHit;

	//Hit reaction
	SpriteRenderer sprite;
	float invulnerabilityPeriod;

	// Use this for initialization
	void Start () {
		//Convert 0-100 number to a useful 0-1 multiplicitive reduction
		pdr = Mathf.Clamp(1 - (percentDamageReduction / 100), 0, 1);
		health = maximumHealth;

		sprite = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		//Basic destroy sequence
		if (health <= 0) {
			GameObject.Destroy(this.gameObject);
		}

		//Recover from red flash
		if (sprite.color != Color.white) {
			sprite.color = new Color(sprite.color.r, Mathf.Lerp(sprite.color.g, 1f, 0.1f), Mathf.Lerp(sprite.color.b, 1f, 0.1f));
		}
		if (invulnerabilityPeriod > 0) {
			invulnerabilityPeriod -= Time.deltaTime;
		}
	}

	//Damages health
	public void Damage (float dmg) {
		if (invulnerabilityPeriod <= 0) {
			FlashFromHit();
			invulnerabilityPeriod = invulnerabilityAfterHit;
			health -= Mathf.Clamp((dmg - fixedDamageReduction), 0, dmg) * pdr;
		}
	}

	//Flash sprite when hit
	void FlashFromHit() {
		sprite.color = Color.red;

	}
}
