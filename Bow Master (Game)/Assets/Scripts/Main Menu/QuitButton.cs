using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "ButtonPresser") {
			MainMenu.QuitGame();
		}
	}
}
