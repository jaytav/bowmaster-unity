using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayButton : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "ButtonPresser") {
			MainMenu.PlayGame();
		}
	}
}
