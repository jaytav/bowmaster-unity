using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public static bool playerInRange;
	public float timeBetweenAttacks = 3f;
	public int attackDamage = 10;

	private GameObject player;
	private PlayerHealth playerHealth;
	private EnemyHealth enemyHealth;
	private EnemyMovement enemyMovement;
	private Animator enemyAnim;
	private float timer;

	void Awake() {
		timer = timeBetweenAttacks;
		player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
		enemyMovement = GetComponent<EnemyMovement>();
		enemyAnim = GetComponent<Animator>();
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) {
			enemyAnim.SetBool("Attacking", true);
			StartCoroutine(WaitAttack());
			Attack();
		}

		if (playerHealth.currentHealth <= 0) {
			
		}
	}

	void Attack() {
		timer = 0f;

		if (playerHealth.currentHealth > 0) {
			playerHealth.TakeDamage(attackDamage);
		}
	}

	IEnumerator WaitAttack() {
		enemyMovement.enabled = false;
		yield return new WaitForSeconds(1.5f);
		enemyMovement.enabled = true;
		enemyAnim.SetBool("Attacking", false);
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
