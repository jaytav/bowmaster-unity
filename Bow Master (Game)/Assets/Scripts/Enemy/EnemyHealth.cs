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
	public int currencyValue;
	public int flashAmount;
	public float flashTime;
	public AudioClip enemyHurt;
	public AudioClip enemyDie;

	private SpriteRenderer enemySR;
	private Shader whiteShader;
	private Shader defaultShader;
	private Animator enemyAnim;
	private EnemyMovement enemyMovement;
	private GameObject gameController;
	private EnemyManager enemyManager;

	void Awake() {
		currentHealth = startingHealth;
	}

	void Start() {
		enemySR = GetComponent<SpriteRenderer>();
		whiteShader = Shader.Find("GUI/Text Shader");
		defaultShader = Shader.Find("Sprites/Default");

		enemyAnim = GetComponent<Animator>();
		enemyMovement = GetComponent<EnemyMovement>();

		gameController = GameObject.FindGameObjectWithTag("GameController");
		enemyManager = gameController.GetComponent<EnemyManager>();
	}

	void Update() {
		if (currentHealth <= 0) {
			enemyHealthAmount.text = "";
		} else enemyHealthAmount.text = currentHealth.ToString();
	}

	public void TakeDamage(int amount) {
		currentHealth -= amount;
		SoundManager.instance.PlaySingle(enemyHurt);
		StartCoroutine(TakeDamageFlash());
		if (currentHealth <= 0 && enemyMovement.enabled) {
			Die();
		}
	}

	void Die() {
		enemyAnim.SetTrigger("Die");
		SoundManager.instance.PlaySingle(enemyDie);
		enemyMovement.enabled = false;
		enemyManager.DropCurrency(currencyValue, transform.position);
		StartCoroutine(WaitDeath());
	}

	IEnumerator WaitDeath() {
		yield return new WaitForSeconds(deathTime);
		Instantiate(deadEnemy, transform.position, transform.rotation);
		Destroy(gameObject);
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
		enemySR.material.shader = whiteShader;
	}

	void DefaultSprite() {
		enemySR.material.shader = defaultShader;
	}

}
