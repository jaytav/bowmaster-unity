using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoors : MonoBehaviour {

	public GameObject door;
	public Transform entrance;
	public Transform exit;

	void Start() {
		Instantiate(door,
					entrance.position,
					entrance.rotation);

		Instantiate(door,
					exit.position,
					exit.rotation);
	}
}
