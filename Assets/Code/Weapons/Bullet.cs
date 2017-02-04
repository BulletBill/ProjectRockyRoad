using UnityEngine;
using System.Collections;

//Rigidbody is used to move the bullet and a circle collider is used to check for hits
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(CircleCollider2D))]
public class Bullet: MonoBehaviour {

    public float damage;
    public float areaOfEffect;
	[Tooltip("1-10. 5 is average")]
	public float projectileSpeed;
	[Tooltip("Lifetime in seconds")]
	public float lifeTime;

    GameObject owner;
	bool hitSomething;

	// Use this for initialization
	void Start() {
		owner = transform.root.gameObject;
		hitSomething = false;
	}

	// Update is called once per frame
	void Update () {
		lifeTime -= Time.deltaTime;
		if (lifeTime <= 0 || hitSomething) {
			GameObject.Destroy(this.gameObject);
		}
	}

	// Handle bullet hit
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject != owner && other != null) {
			//Debug.Log("Hit object: " + gameObject.name);
			ShipHealthSystem hp = other.gameObject.GetComponent<ShipHealthSystem>();
			if (hp != null) {
				hp.Damage(damage);
				hitSomething = true;
			}
		}
	}
}