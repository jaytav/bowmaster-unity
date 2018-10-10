using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KingSlimeAttack : MonoBehaviour {

	public float timeUntilNextAttack; //how often boss performs attacks
	public float spikeSpawnWaitTime;
	public Transform spikeSpawnPoints;
	public GameObject kingSlimeProjectile;

	private float nextAttackTimer;
	private bool isAttacking;

	void Start() {
		isAttacking = false;
	}

	void Update() {
		if (!isAttacking) {
			nextAttackTimer += Time.deltaTime;
		}

		if (nextAttackTimer >= timeUntilNextAttack) {
			nextAttackTimer = 0f;
			Attack();
		}
	}

	void Attack() {
		isAttacking = true;
		ShootSpike();
	}

	void ShootSpike() {
		StartCoroutine(SpawnProjectileWait());
	}

	IEnumerator SpawnProjectileWait() {
		foreach (Transform child in spikeSpawnPoints) {
			Instantiate(kingSlimeProjectile, child.position, child.rotation);
			yield return new WaitForSeconds(spikeSpawnWaitTime);
		}
		isAttacking = false;
	}
}
