using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public float speed = 3f;
	public static float direction = -1;
	public static bool isMoving = true;

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
		if (direction == -1f) { enemySR.flipX = true; } else enemySR.flipX = false;
	}
}
