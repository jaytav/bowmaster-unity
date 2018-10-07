using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoors : MonoBehaviour {

	public GameObject door;
	public Transform entranceSpawnPoint;
	public Transform exitSpawnPoint;

	void Start() {
		if (entranceSpawnPoint) {
			GameObject entrance = Instantiate(door, entranceSpawnPoint.position, entranceSpawnPoint.rotation);
			entrance.transform.parent = gameObject.transform;
		}
		
		if (exitSpawnPoint) {
			GameObject exit = Instantiate(door, exitSpawnPoint.position, exitSpawnPoint.rotation);
			exit.transform.parent = gameObject.transform;
		}

		DestroyExcess();
	}

	void DestroyExcess() { //destroy uneeded GameObjects and/or components
		Destroy(this);
		Destroy(entranceSpawnPoint.gameObject);
		Destroy(exitSpawnPoint.gameObject);
	}
}
