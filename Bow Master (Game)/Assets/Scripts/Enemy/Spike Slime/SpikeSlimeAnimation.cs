using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSlimeAnimation : MonoBehaviour {

	private Animator spikeSlimeAnim;

	void Start() {
		spikeSlimeAnim = GetComponent<Animator>();
	}

	void Update() {
		IsMoving();
	}

	void IsMoving() {
		spikeSlimeAnim.SetBool("IsMoving", EnemyMovement.isMoving);
	}

	public void Attack() {
		spikeSlimeAnim.SetTrigger("Attack");
	}
}
