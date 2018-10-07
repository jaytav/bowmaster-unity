using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
	
	public GameObject[] enemies;
	public Transform enemySpawnPoints;
	public GameObject enemySpawnPS;

	private float timeToDestroy;
	private float timeToWaitForParticles;

	void Start() {
		timeToDestroy = 2f;
		timeToWaitForParticles = 0.5f;

		foreach (Transform child in enemySpawnPoints) {
			Instantiate(enemySpawnPS, child.position, child.rotation, child); //creates enemy spawn particle effect
		}
		StartCoroutine(WaitForParticles());
	}

	void DestroyExcess() { //destroy uneeded GameObjects and/or components
		Destroy(enemySpawnPoints.gameObject, timeToDestroy);
		Destroy(this);
	}

	IEnumerator WaitForParticles() {
		yield return new WaitForSeconds(timeToWaitForParticles);
		foreach (Transform child in enemySpawnPoints) { //goes through all children Transforms inside enemySpawnPoints
			int enemyNum = Random.Range(0, enemies.Length); //randomly choose enemy
			Instantiate(enemies[enemyNum], child.position, child.rotation, gameObject.transform); //spawn enemy on iterated child with room as parent
		}
		DestroyExcess();
	}
}
