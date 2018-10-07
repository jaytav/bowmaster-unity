using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttack : MonoBehaviour {

	public bool playerInRange;
	public float timeBetweenAttacks = 5f;
	public int attackDamage = 2;
	public float stopWait = 1.5f;

	public float rangeX = 10f;
	public float rangeY = 1f;

	public GameObject projectile;

	private EnemyHealth enemyHealth;
	private EnemyMovement enemyMovement;
	private BoxCollider2D rangeAttackCol;

	private Animator enemyAnim;
	private float timer;

	void Awake() {
		timer = timeBetweenAttacks;
		enemyHealth = GetComponentInParent<EnemyHealth>();
		enemyMovement = GetComponentInParent<EnemyMovement>();
		enemyAnim = GetComponentInParent<Animator>();
		rangeAttackCol = GetComponent<BoxCollider2D>();
		rangeAttackCol.size = new Vector2(rangeX, rangeY);
	}

	void Update() {
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) {
			enemyAnim.SetTrigger("Attack");
			Attack();
			StartCoroutine(WaitAttack());
		}

		rangeAttackCol.offset = new Vector2(rangeX/2 * enemyMovement.direction, 
											rangeAttackCol.offset.y);
	}

	IEnumerator WaitAttack() {
		enemyMovement.enabled = false;
		yield return new WaitForSeconds(stopWait);
		enemyMovement.enabled = true;
	}

	void Attack() {
		timer = 0f;

		Instantiate(projectile, transform.position, transform.rotation);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			playerInRange = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			playerInRange = false;
		}
	}
}
