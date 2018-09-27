using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Slider healthBar;
	public Text healthNum;

	private GameObject player;
	private PlayerHealth playerHealth;

	void Start() {
		player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();

		healthBar.maxValue = playerHealth.startingHealth;
	}

	void Update() {
		healthBar.value = playerHealth.currentHealth;

		healthNum.text = playerHealth.currentHealth + "/" + playerHealth.startingHealth;
	}
}
