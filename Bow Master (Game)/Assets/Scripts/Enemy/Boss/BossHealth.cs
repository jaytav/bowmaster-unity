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
	private KingSlimeAttack kingSlimeAttack;
	private BoxCollider2D kingSlimeCol;
	private Shader whiteShader;
	private Shader defaultShader;
	private Animator bossAnim;
	private float currentLerp;

	void Awake() {
		currentHealth = startingHealth;
		bossHealthBar.value = 0f;
	}

	void Start() {
		kingSlimeAttack = GetComponent<KingSlimeAttack>();
		kingSlimeCol = GetComponent<BoxCollider2D>();
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
		bossAnim.Play("KingSlime_Damaged"); //damaged animation

		if (currentHealth <= 0) {
			Die();
			flashTime = flashTime * 3f; //3 times flash time when dead
		}
		
		StartCoroutine(TakeDamageFlash());
		UpdateHealth();
	}

	void Die() {
		StartCoroutine(WaitForFlash());
	}

	void UpdateHealth() { //update the boss health UI
		if (currentHealth <= 0) {
			bossHealthAmount.text = "";
		} else bossHealthAmount.text = currentHealth.ToString();

		bossHealthBar.value = (float)currentHealth / (float)startingHealth;
	}

	IEnumerator TakeDamageFlash() { //visual effect enemy flashing to indicate they took damage
		for (int i = 0; i < flashAmount; i++) { //flashes multiple times
			WhiteSprite();
			yield return new WaitForSeconds(flashTime);
			DefaultSprite();
			yield return new WaitForSeconds(flashTime);
		}
	}

	IEnumerator WaitForFlash() { //wait for flash to finish
		yield return new WaitForSeconds((flashTime * flashAmount * 2));
		bossAnim.Play("KingSlime_Die"); //play death animation
		kingSlimeCol.enabled = false; //disable collider
		this.enabled = false; //disable bosshealth script
		kingSlimeAttack.enabled = false; //disable king slime attack script
		
	}

	void WhiteSprite() {
		bossSR.material.shader = whiteShader; //turn boss white
	}

	void DefaultSprite() {
		bossSR.material.shader = defaultShader; //turn boss back to default color
	}
}
