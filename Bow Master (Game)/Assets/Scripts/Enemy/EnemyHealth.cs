using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;
	public GameObject deadEnemy; //enemy death model
	public float deathTime = 2f;
	public Text enemyHealthAmount;

	private Animator enemyAnim;
	private EnemyMovement enemyMovement;

	void Awake() {
		currentHealth = startingHealth;
	}

	void Start() {
		enemyAnim = GetComponent<Animator>();
		enemyMovement = GetComponent<EnemyMovement>();
	}

	void Update() {
		if (currentHealth < 0) {
			enemyHealthAmount.text = "";
		} else enemyHealthAmount.text = currentHealth.ToString();
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;

		if (currentHealth <= 0) {
			Die();
		}
	}

	void Die() {
		enemyAnim.SetTrigger("Die");
		enemyMovement.enabled = false;
		StartCoroutine(WaitDeath());
	}

	IEnumerator WaitDeath() {
		yield return new WaitForSeconds(deathTime);
		Instantiate(deadEnemy, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
