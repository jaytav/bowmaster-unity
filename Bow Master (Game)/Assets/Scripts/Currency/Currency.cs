using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {

	public int value; //value of currency
	public float speed; //speed when moving to player

	private CapsuleCollider2D capsuleCollider2D; //currency physical collider
	private Rigidbody2D rigidbody2D; //currency rigidbody2D

	private GameManager gameManager; //gamemanager used to update currency amount on player pickup

	//position of currency in relation to player so it moves to them
	private Vector2 startPos;
	private Vector2 targetPos;
	private Vector2 directionToTarget;

	void Start() {
		GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
		
		if (gameController != null) { //if gameController exists get GameManager script from it
            gameManager = gameController.GetComponent<GameManager>();
        }
        else if (gameManager == null) { //if GameManager script doesn't exist in the gameController
            Debug.Log ("Cannot find 'GameManager' script");
        }

		capsuleCollider2D = GetComponent<CapsuleCollider2D>();
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		//disables physical collider, gravity and mass when player enters range
		if (col.gameObject.tag == "PlayerRange") {
			capsuleCollider2D.enabled = false;
			rigidbody2D.gravityScale = 0;
			rigidbody2D.mass = 0;
		}

		if (col.gameObject.tag == "Player") { //adds to currency if touches player physical collider
			gameManager.AddCurrency(value);
			Destroy(gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		//disables physical collider, gravity and mass when player enters range
		if (col.gameObject.tag == "PlayerRange") {
			capsuleCollider2D.enabled = true;
			rigidbody2D.gravityScale = 1;
			rigidbody2D.mass = 1;
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerRange") {
			startPos = transform.position; //get currency current position
			targetPos = col.gameObject.transform.position; //get player current position
			directionToTarget = targetPos - startPos; //calculate direction from currency to player
			
			float distance = //get distance between currency and player
				Vector2.Distance(col.gameObject.transform.position,
								transform.position); 
							
			//move currency smoothly towards player, moves faster the closer currency is to the player
			transform.Translate((directionToTarget.x * (speed - distance/10) * Time.deltaTime),
								(directionToTarget.y * (speed - distance/10) * Time.deltaTime),
								0f);
		}
	}
}
