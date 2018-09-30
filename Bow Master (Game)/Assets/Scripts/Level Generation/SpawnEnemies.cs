using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
	
	public GameObject[] enemies;
	public Transform[] enemySpawns;

	void Start() {
		for (int i = 0; i < enemySpawns.Length; i++) {
			int enemyNum = Random.Range(0, enemies.Length);
			Instantiate(enemies[enemyNum], 
						enemySpawns[i].position, 
						enemySpawns[i].rotation);
		}
	}
}
