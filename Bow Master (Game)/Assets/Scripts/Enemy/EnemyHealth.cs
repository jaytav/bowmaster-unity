using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;
	public GameObject deadEnemy; //enemy death model

	private ParticleSystem enemyPS;
	private Animator enemyAnim;
	private EnemyMovement enemyMovement;

	void Awake() {
		currentHealth = startingHealth;
	}

	void Start() {
		enemyPS = GetComponent<ParticleSystem>();
		enemyAnim = GetComponent<Animator>();
		enemyMovement = GetComponent<EnemyMovement>();
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;

		if (currentHealth <= 0) {
			Die();
		}
	}

	void Die() {
		enemyPS.Play();
		enemyAnim.SetTrigger("Die");
		enemyMovement.enabled = false;
		StartCoroutine(WaitDeath());
	}

	IEnumerator WaitDeath() {
		yield return new WaitForSeconds(2f);
		Instantiate(deadEnemy, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
