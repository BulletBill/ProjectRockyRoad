using UnityEngine;
using System.Collections;

public class BulletEmitter : MonoBehaviour {

    public Object bulletFired;
	[Tooltip("Time in the weapon's firing cycle when this bullet fires")]
	public float offsetDelay;
	[Tooltip("Angle of deviation from firing angle")]
	public float aimDeviation;
	[Tooltip("Number of bullets launched simultaneously")]
	public float bulletCount = 1;
	public bool hasFired { get; protected set; }

	// Use this for initialization
	void Start() {
		//Firing offset cannot be larger than the weapon's fire rate
		Mathf.Clamp(offsetDelay, 0, transform.parent.GetComponent<ShipWeapon>().fireRate);
	}

	public void Fire() {
		if (!hasFired) {
			hasFired = true;

			for (int i = 0; i < bulletCount; i++) {
				GameObject newBullet = Instantiate(bulletFired, transform.position, transform.rotation) as GameObject;
				Rigidbody2D bulletPhysics = newBullet.GetComponent<Rigidbody2D>();
				Bullet bulletScript = newBullet.GetComponent<Bullet>();

				bulletPhysics.AddTorque(10f);
				Vector2 dir = Quaternion.AngleAxis(transform.eulerAngles.z + GetDeviation(), Vector3.forward) * Vector3.up;
				bulletPhysics.AddForce(dir * (bulletScript.projectileSpeed * 0.1f), ForceMode2D.Impulse);
			}
		}
	}

	public void Reset() {
		hasFired = false;
	}

	void OnDrawGizmos() {
		Gizmos.color = Color.blue;

		Gizmos.DrawSphere(transform.position, 0.025f);

		Vector3 directionPoint = Quaternion.AngleAxis(transform.eulerAngles.z - (aimDeviation / 2), Vector3.forward) * Vector3.up;
		Gizmos.DrawLine(transform.position, transform.position + (directionPoint * 0.5f));

		directionPoint = Quaternion.AngleAxis(transform.eulerAngles.z + (aimDeviation / 2), Vector3.forward) * Vector3.up;
		Gizmos.DrawLine(transform.position, transform.position + (directionPoint * 0.5f));
	}

	float GetDeviation() {
		return Random.Range(-aimDeviation / 2, aimDeviation / 2);
	}
}
