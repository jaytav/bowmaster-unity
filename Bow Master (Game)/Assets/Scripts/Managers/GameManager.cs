using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Text currencyText; //currency text on UI
	public Animator UIAnim;
	public bool playerDead;
	public bool bossDead;
	public int currency; //currency value
	public PlayerShooting playerShooting;
	public PlayerMovement playerMovement;
	public float timerUntilPlayerMoves;
	public static GameManager instance = null;

	private bool stopper;
	private float timer = 0f;
	private float timer2 = 0f;
	private float waitTimeBeforeRestart = 3.5f;

	void Start() {
		if (instance == null) instance = this;
		else if (instance != null) Destroy(this);

		stopper = true;
		playerDead = false;
		bossDead = false;

		currency = 0; //start with 0 currency
		UpdateCurrency();
		SoundManager.instance.ChangeMusic();
	}
	
	void Update() {
		if (stopper) {
			timer2 += Time.deltaTime;
		}

		if (timer2 > timerUntilPlayerMoves) {
			playerShooting.enabled = true;
			playerMovement.enabled = true;
			stopper = false;
			timer2 = 0f;
		}

		if (playerDead) {
			timer += Time.deltaTime;
			SoundManager.instance.sources[1].volume = 0f;
			SoundManager.instance.sources[2].volume = 0f;
		}

		if (bossDead) {
			timer += Time.deltaTime;
			SoundManager.instance.sources[1].volume = 0f;
			SoundManager.instance.sources[2].volume = 0f;
		}

		if (Input.GetButtonDown("Restart") && timer > waitTimeBeforeRestart) {
			if (bossDead)
				SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);
			else if (playerDead)
				SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
		}

		if (Input.GetKeyDown(KeyCode.Escape)) {
			SceneManager.LoadSceneAsync(0); //hard restart game
		}

		if (Input.GetKeyDown(KeyCode.Backspace)) {
			SceneManager.LoadSceneAsync(1); //hard restarts level
		}
	}

	public void AddCurrency(int currencyAmount) { //add currency to current amount
		currency += currencyAmount;
		UIAnim.Play("PlayerGetCurrency");
		UpdateCurrency();
	}

	public void RemoveCurrency(int currencyAmount) { //remove currency to current amount (purchasing)
		currency -= currencyAmount;
		UpdateCurrency();
	}

	void UpdateCurrency() { //update currency text on UI
		currencyText.text = currency.ToString();
	}
}
