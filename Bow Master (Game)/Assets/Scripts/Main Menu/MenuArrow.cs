using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuArrow : MonoBehaviour {

	public float speed;
	private BoxCollider2D arrowCol;
	
	void Update() {
		arrowCol = GetComponent<BoxCollider2D>();
		transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Button") {
			arrowCol.enabled = false;
		}
	}
}
