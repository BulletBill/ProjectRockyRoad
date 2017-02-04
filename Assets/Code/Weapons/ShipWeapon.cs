using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipWeapon : MonoBehaviour {

	//Timeline
	[Tooltip("Delay between firing cycles in seconds.")]
	public float fireRate;
	float timer = 0;
	bool waitToFire = false;

	//Organization
	public int firingGroup;
    public List<BulletEmitter> ports;

	//Recieved input
	bool fire = false;

    // Use this for initialization
    void Start() {
        if (ports != null) {
            foreach (BulletEmitter b in ports) {
				if (b != null) {
					b.transform.parent = transform;
				}
            }
        }
    }

	// Update is called once per frame
	void Update() {
		//Increment and handle firing timeline
		if (!waitToFire) {
			timer += Time.deltaTime;
			
			foreach (BulletEmitter b in ports) {
				if (timer > b.offsetDelay && b.hasFired == false) {
					waitToFire = true;
				}
			}

			if (timer > fireRate) {
				ResetAllWeapons();
				timer = 0;
			}
		}

		//Handle input, fire ready weapons
		if (fire) {
			fire = false;
			waitToFire = false;

			foreach (BulletEmitter b in ports) {
				if (b != null) {
					if (timer > b.offsetDelay) {
						b.Fire();
					}
				}
			}
		}
	}

	void ResetAllWeapons() {
		foreach (BulletEmitter b in ports) {
			b.Reset();
		}
	}

	public void Fire () {
		fire = true;
	}
}
