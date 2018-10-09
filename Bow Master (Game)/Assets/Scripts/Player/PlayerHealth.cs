using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

	public GameObject deadPlayer;
	public GameObject takeDamageImage;
	public float takeDamageImageTime;
	public int startingHealth = 50;
	public int currentHealth;
	public Animator UIAnim;

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
		UIAnim.Play("PlayerTakeDamage");
		StartCoroutine(WaitTakeDamageImage());
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

	IEnumerator WaitTakeDamageImage() {
		takeDamageImage.SetActive(true);
		yield return new WaitForSeconds(takeDamageImageTime);
		takeDamageImage.SetActive(false);
	}
}
