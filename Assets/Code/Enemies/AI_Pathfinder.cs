using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI_Pathfinder : MonoBehaviour {

	ShipMover mover;

	//Design variables set in editor
	public bool fixedFacing = false;
    public path pathToFollow;

    //Variables used by the game
    int destinationNodeIndex = 0;
	Vector2 destinationPos;
	pathNode destinationNode;
	float x;
	float y;
    float wait = 0;

    //Cached ship objects
    WeaponCollective weapon;

	// Use this for initialization
	void Start () {
        //Cache components
		mover = GetComponent<ShipMover>();
		weapon = GetComponent<WeaponCollective>();
		destinationNode = pathToFollow.waypoints[destinationNodeIndex];
	}
	
	// Update is called once per frame
	void Update () {
		x = transform.position.x;
		y = transform.position.y;

		if (wait > 0) {
			wait -= Time.deltaTime;
		}

		if (destinationNode != null && wait <= 0) {
			if (fixedFacing) {
				mover.MoveToPoint(destinationPos);
			} else {
				mover.FacePoint(destinationPos);
				mover.MoveToFacing();
			}

			float distanceToWaypoint = Mathf.Sqrt(Mathf.Pow((x - destinationPos.x), 2) + Mathf.Pow((y - destinationPos.y), 2));
			if (distanceToWaypoint < destinationNode.radius) {
				HitWaypoint();
			}
		}
	}

	void HitWaypoint () {
		wait = destinationNode.wait;
		ExecuteCommand(destinationNode.command);
        destinationNodeIndex = destinationNode.NextNode;

		destinationNode = pathToFollow.waypoints[destinationNodeIndex];
		destinationPos = pathToFollow.GetNodePos(destinationNodeIndex);
	}

	void ExecuteCommand(pathNode.commands command) {
		if (command == pathNode.commands.FIRE) {
			if (weapon) {
                weapon.FireWeaponGroup(1);
            }
		}
		if (command == pathNode.commands.DESTROY) {
            GameObject.Destroy(this.gameObject);
        }
	}

	public void SetPath(path NewPath) {
		pathToFollow = NewPath;
		destinationNodeIndex = 0;
		destinationNode = pathToFollow.waypoints[destinationNodeIndex];
		destinationPos = pathToFollow.GetNodePos(destinationNodeIndex);
	}
}
