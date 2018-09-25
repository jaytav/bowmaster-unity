using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;

	void Awake() {
		currentHealth = startingHealth;
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;

		if (currentHealth <= 0) {
			Die();
		}
	}

	void Die() {
		Destroy(gameObject);
	}

}
