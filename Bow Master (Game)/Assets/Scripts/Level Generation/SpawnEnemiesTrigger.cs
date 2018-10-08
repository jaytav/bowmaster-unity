using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesTrigger : MonoBehaviour {

	private SpawnEnemies spawnEnemies;

	void Start() {
		spawnEnemies = GetComponentInParent<SpawnEnemies>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player") {
			spawnEnemies.enabled = true;
			Destroy(gameObject);
		}
	}
}
