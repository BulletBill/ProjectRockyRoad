using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WeaponCollective : MonoBehaviour {

    public bool drawHardpoints = true;
    public List<Hardpoint> weapons = new List<Hardpoint>();

    // Use this for initialization
    void Start() {
        //Align weapon parents and position
        if (weapons != null) {
            foreach (Hardpoint h in weapons) {
				if (h != null && h.weapon != null) {
					h.weapon.transform.parent = transform;
					h.weapon.transform.localPosition = new Vector3(h.xOffset, h.yOffset, 0);
				}
            }
        }
    }

    // Update is called once per frame
    void Update() {
    }

    //Fires all weapons with matching group
    public void FireWeaponGroup(int group) {
		foreach (Hardpoint s in weapons) {
			if (s != null) {
				if (s.weapon.firingGroup == group) {
					s.weapon.Fire();
				}
			}
		}
    }

    void OnDrawGizmos() {
        if (weapons.Count > 0 && drawHardpoints) {
            float lineSize = 0.2f;
            Vector3 point = new Vector3();
            foreach (Hardpoint h in weapons) {
                point.Set(transform.position.x + h.xOffset, transform.position.y + h.yOffset, transform.position.z);

                Gizmos.color = Color.red;
                if (h.weapon == null) { Gizmos.color = Color.gray; }
                Gizmos.DrawLine(new Vector3(point.x - lineSize, point.y, point.z), new Vector3(point.x + lineSize, point.y, point.z));
                Gizmos.DrawLine(new Vector3(point.x, point.y - lineSize, point.z), new Vector3(point.x, point.y + lineSize, point.z));
            }
        }
    }
}
