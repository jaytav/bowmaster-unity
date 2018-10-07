using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoors : MonoBehaviour {

	public GameObject door;
	public Transform entrance;
	public Transform exit;

	void Start() {
		if (entrance) {
			Instantiate(door,
					entrance.position,
					entrance.rotation);
		}
		
		if (exit) {
			Instantiate(door,
					exit.position,
					exit.rotation);
		}
	}
}
