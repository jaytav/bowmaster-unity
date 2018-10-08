using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour {

	public GameObject boss;
	public Transform bossSpawnPoint;
	public GameObject bossSpawnPS;

	private float timeToDestroy;
	private float timeToWaitForParticles;

	void Start() {
		timeToDestroy = 2f;
		timeToWaitForParticles = 0.5f;
		
		StartCoroutine(WaitForParticles());
	}

	IEnumerator WaitForParticles() {
		Instantiate(bossSpawnPS,
					bossSpawnPoint.position,
					bossSpawnPoint.rotation,
					bossSpawnPoint.gameObject.transform);

		yield return new WaitForSeconds(timeToWaitForParticles);

		Instantiate(boss,
					bossSpawnPoint.position,
					bossSpawnPoint.rotation,
					gameObject.transform);

		DestroyExcess();
	}

	void DestroyExcess() {
		Destroy(bossSpawnPoint.gameObject, timeToDestroy);
		Destroy(this);
	}
}
