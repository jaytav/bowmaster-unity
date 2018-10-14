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
		timeToDestroy = 3f;
		timeToWaitForParticles = 0.5f;
		
		StartCoroutine(WaitForCameraSwitch());
		StartCoroutine(WaitForParticles());
	}

	IEnumerator WaitForCameraSwitch() { //make camera follow boss for x seconds, then back to player.
		GameObject player = GameObject.FindGameObjectWithTag("Player"); //get player transform to return back to it
		CameraManager.instance.ChangeTarget(bossSpawnPoint);
		yield return new WaitForSeconds(waitForSwitch);
		CameraManager.instance.CameraZoom(20f);
		CameraManager.instance.ChangeTarget(player.transform);
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
