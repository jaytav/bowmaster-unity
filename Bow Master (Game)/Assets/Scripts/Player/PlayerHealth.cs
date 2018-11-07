using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	public GameObject deadPlayer;
	public GameObject takeDamageImage;
	public float takeDamageImageTime;
	public int startingHealth = 50;
	public int currentHealth;
	public Animator UIAnim;
	public AudioClip takeDamageAudio;

	private bool isDead;
	private bool damaged;
	private float deathTimer;

	void Awake() {
		currentHealth = startingHealth;
	}

	void Update() {
		if (damaged) {
			print("got hit lol");
		}
		damaged = false;

		if (isDead) {
			deathTimer += Time.deltaTime;
			print(deathTimer);
		}

		if (gameObject.transform.position.y < -50f) {
			Die();
		} 
	}

	public void TakeDamage(int amount) {
		damaged = true;
		UIAnim.Play("PlayerTakeDamage");
		SoundManager.instance.PlaySingle(takeDamageAudio);
		StartCoroutine(WaitTakeDamageImage());
		currentHealth -= amount;

		if (currentHealth <= 0 && !isDead) {
			Die();
		}
	}

	private void Die() {
		isDead = true;
		UIAnim.SetTrigger("PlayerDie");
		GameManager.instance.playerDead = true;
		Destroy(gameObject); //destroy player
		Instantiate(deadPlayer, transform.position, transform.rotation); //replace with dead version
	}

	IEnumerator WaitTakeDamageImage() {
		takeDamageImage.SetActive(true);
		yield return new WaitForSeconds(takeDamageImageTime);
		takeDamageImage.SetActive(false);
	}
}
