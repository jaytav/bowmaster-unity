using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSlimeAnimation : MonoBehaviour {

	private Animator spikeSlimeAnim;
	private EnemyMovement enemyMovement;

	void Start() {
		spikeSlimeAnim = GetComponent<Animator>();
		enemyMovement = GetComponent<EnemyMovement>();
	}

	void Update() {
		IsMoving();
	}

	void IsMoving() {
		spikeSlimeAnim.SetBool("IsMoving", enemyMovement.isMoving);
	}

	public void Attack() {
		spikeSlimeAnim.SetTrigger("Attack");
	}
}
