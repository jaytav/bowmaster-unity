using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;
	public Text bossHealthAmount;
	public Slider bossHealthBar;

	private Animator bossAnim;
	private float currentLerp;

	void Awake() {
		currentHealth = startingHealth;
		bossHealthBar.value = 0f;
	}

	void Start() {
		bossAnim = GetComponent<Animator>();
	}

	void Update() {
		if (currentLerp < 1f) {
			currentLerp += Time.deltaTime;
			bossHealthBar.value = Mathf.Lerp(0f, 1f, currentLerp);
		}
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
		if (currentHealth <= 0) { Die(); }
		UpdateHealth();
	}

	void Die() {
		print("boss ded lol");
	}

	void UpdateHealth() {
		if (currentHealth <= 0) {
			bossHealthAmount.text = "";
		} else bossHealthAmount.text = currentHealth.ToString();

		bossHealthBar.value = (float)currentHealth / (float)startingHealth;
	}
}
