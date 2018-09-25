using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 50;
	public int currentHealth;
	public PlayerMovement playerMovement;

	private bool isDead;
	private bool damaged;

	void Awake() {
		playerMovement = GetComponent<PlayerMovement>();
		currentHealth = startingHealth;
	}

	void Update() {
		if (damaged) {
			print("got hit lol");
		}
		damaged = false;
	}

	public void TakeDamage(int amount) {
		damaged = true;
		currentHealth -= amount;

		if (currentHealth <= 0 && !isDead) {
			Die();
		}
	}

	private void Die() {
		isDead = true;
		playerMovement.enabled = false;
	}
}
