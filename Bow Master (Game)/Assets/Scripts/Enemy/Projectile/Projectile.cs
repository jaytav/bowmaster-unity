using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public int damage;
	public float timeBeforeMove;

	private float timeTaken;
	private GameObject player;
	private PlayerHealth playerHealth;
	private Vector2 targetPos;
	private Vector2 startPos;
	private Vector2 directionToTarget;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		playerHealth = player.GetComponent<PlayerHealth>();

		startPos = transform.position;
		targetPos = player.transform.position;
		directionToTarget = targetPos - startPos;
	}

	void Update() {
		timeTaken += Time.deltaTime;

		if (timeTaken > timeBeforeMove) {
			transform.Translate(directionToTarget.x * Time.deltaTime,
							directionToTarget.y * Time.deltaTime, 
							0f);
		}
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			if (playerHealth.currentHealth > 0) {
				playerHealth.TakeDamage(damage);
			}
			Destroy(gameObject);
		}
	}
}
