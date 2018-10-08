using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour {

	public int startingHealth = 10;
	public int currentHealth;
	public Text bossHealthAmount;
	public Slider bossHealthBar;
	public int flashAmount;
	public float flashTime;

	private SpriteRenderer bossSR;
	private Shader whiteShader;
	private Shader defaultShader;
	private Animator bossAnim;
	private float currentLerp;

	void Awake() {
		currentHealth = startingHealth;
		bossHealthBar.value = 0f;
	}

	void Start() {
		bossSR = GetComponent<SpriteRenderer>();
		whiteShader = Shader.Find("GUI/Text Shader");
		defaultShader = Shader.Find("Sprites/Default");

		bossAnim = GetComponent<Animator>();
	}

	void Update() {
		if (currentLerp < 1f) {
			currentLerp += Time.deltaTime / 4f;
			bossHealthBar.value = Mathf.Lerp(0f, 1f, currentLerp);
		}
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
		StartCoroutine(TakeDamageFlash());

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

	IEnumerator TakeDamageFlash() { //visual effect enemy flashing to indicate they took damage
		for (int i = 0; i < flashAmount; i++) {
			WhiteSprite();
			yield return new WaitForSeconds(flashTime);
			DefaultSprite();
			yield return new WaitForSeconds(flashTime);
		}
	}

	void WhiteSprite() {
		bossSR.material.shader = whiteShader;
	}

	void DefaultSprite() {
		bossSR.material.shader = defaultShader;
	}
}
