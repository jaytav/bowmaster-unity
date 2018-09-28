using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 3f;
	public float direction = -1;
	public float drawnDirection = 1f;
	public bool isMoving = true;

	private SpriteRenderer enemySR;
	private Animator enemyAnim;

	void Start() {
		enemySR = GetComponent<SpriteRenderer>();
		enemyAnim = GetComponent<Animator>();
	}

	void Update() {
		Move();
		Flip();
	}

	void Move() {
		if (isMoving) {
			transform.Translate(speed * direction * Time.deltaTime, 0, 0);
		}
		enemyAnim.SetBool("IsMoving", isMoving);
	}

	void Flip() {
		if (direction == -1f * drawnDirection) { enemySR.flipX = true; } else enemySR.flipX = false;
	}
}
