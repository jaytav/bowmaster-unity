using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currency : MonoBehaviour {

	public int value; //value of currency
	public float speed; //speed when moving to player
	public AudioClip currencyGet;

	private GameObject player; //player object

	private GameManager gameManager; //gamemanager used to update currency amount on player pickup

	//position of currency in relation to player so it moves to them
	private Vector2 startPos;
	private Vector2 targetPos;
	private Vector2 directionToTarget;

	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");

		GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
		
		if (gameController != null) { //if gameController exists get GameManager script from it
            gameManager = gameController.GetComponent<GameManager>();
        }
        else if (gameManager == null) { //if GameManager script doesn't exist in the gameController
            Debug.Log ("Cannot find 'GameManager' script");
        }
	}

	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "Player") { //adds to currency if touches player physical collider
			gameManager.AddCurrency(value);
			SoundManager.instance.PlaySingle(currencyGet);
			Destroy(gameObject);
		}
	}

	void Update() {
		startPos = transform.position; //get currency current position
		targetPos = player.transform.position; //get player current position
		directionToTarget = targetPos - startPos; //calculate direction from currency to player
		
		float distance = //get distance between currency and player
			Vector2.Distance(player.transform.position,
							transform.position);
						
		//move currency smoothly towards player, moves faster the closer currency is to the player
		transform.Translate((directionToTarget.x * (speed - distance/10) * Time.deltaTime),
							(directionToTarget.y * (speed - distance/10) * Time.deltaTime),
							0f);
	}
}
