using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

	public Image healthBar;
	public Text healthNum;

	private GameObject player;
	private PlayerHealth playerHealth;

	void Awake() {
		player = GameObject.FindWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();
	}

	void Update() {
		healthBar.fillAmount = (float)playerHealth.currentHealth / (float)playerHealth.startingHealth;

		healthNum.text = playerHealth.currentHealth.ToString();
	}
}
