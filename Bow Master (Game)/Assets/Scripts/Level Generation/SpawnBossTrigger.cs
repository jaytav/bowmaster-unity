using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBossTrigger : MonoBehaviour {

	private SpawnBoss spawnBoss;

	void Start() {
		spawnBoss = GetComponentInParent<SpawnBoss>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag =="Player") { //spawn boss and destroy trigger object
			spawnBoss.enabled = true;
			Destroy(gameObject);
		}
	}
}
