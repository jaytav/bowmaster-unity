using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public GameObject deadPlayer;
	public int startingHealth = 50;
	public int currentHealth;

	private bool isDead;
	private bool damaged;

	void Awake() {
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
		Destroy(gameObject); //destroy player
		Instantiate(deadPlayer, transform.position, transform.rotation); //replace with dead version
	}
}
