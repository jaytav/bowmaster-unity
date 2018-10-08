using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoss : MonoBehaviour {

	public GameObject boss;
	public Transform bossSpawnPoint;
	public GameObject bossSpawnPS;
	public float waitForSwitch;

	private GameObject camera;
	private CameraFollow cameraFollow;
	private float timeToDestroy;
	private float timeToWaitForParticles;

	void Start() {
		camera = GameObject.FindGameObjectWithTag("MainCamera");
		if (camera) { cameraFollow = camera.GetComponent<CameraFollow>(); }

		timeToDestroy = 3f;
		timeToWaitForParticles = 0.5f;
		
		StartCoroutine(WaitForCameraSwitch());
		StartCoroutine(WaitForParticles());
	}

	IEnumerator WaitForCameraSwitch() { //make camera follow boss for x seconds, then back to player.
		Transform playerTransform = cameraFollow.target.transform; //save player to assign back to camerafollow target
		cameraFollow.target = bossSpawnPoint.transform;
		yield return new WaitForSeconds(waitForSwitch);
		cameraFollow.target = playerTransform;
		DestroyExcess();
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
	}

	void DestroyExcess() {
		Destroy(bossSpawnPoint.gameObject, timeToDestroy);
		Destroy(this);
	}
}
