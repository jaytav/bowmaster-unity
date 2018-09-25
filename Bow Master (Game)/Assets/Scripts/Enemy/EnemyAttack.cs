﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

	public float timeBetweenAttacks = 0.5f;
	public int attackDamage = 10;

	private GameObject player;
	private PlayerHealth playerHealth;
	private EnemyHealth enemyHealth;
	private bool playerInRange;
	private float timer;

	void Awake() {
		player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
		enemyHealth = GetComponent<EnemyHealth>();
	}

	void Update () {
		timer += Time.deltaTime;

		if (timer >= timeBetweenAttacks && playerInRange && enemyHealth.currentHealth > 0) {
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
