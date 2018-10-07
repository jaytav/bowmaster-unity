using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
	
	public GameObject[] enemies;
	public Transform enemySpawnPoints;

	void Start() {
		foreach (Transform child in enemySpawnPoints) { //goes through all children Transforms inside enemySpawnPoints
			int enemyNum = Random.Range(0, enemies.Length); //randomly choose enemy
			GameObject enemy = Instantiate(enemies[enemyNum], child.position, child.rotation); //spawn enemy on iterated child and store as GameObject
			enemy.transform.parent = gameObject.transform; //make the enemy a child of room
		}

		DestroyExcess();
	}

	void DestroyExcess() { //destroy uneeded GameObjects and/or components
		Destroy(enemySpawnPoints.gameObject);
		Destroy(this);
	}
}
