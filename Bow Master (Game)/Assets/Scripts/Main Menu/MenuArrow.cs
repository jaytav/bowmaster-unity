using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuArrow : MonoBehaviour {

	public float speed;
	public AudioClip arrowBreakClip;

	private BoxCollider2D arrowCol;
	
	void Start() {
		arrowCol = GetComponent<BoxCollider2D>();
	}

	void Update() {
		transform.Translate(speed * Time.deltaTime, 0f, 0f);
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Button") {
			arrowCol.enabled = false;
			SoundManager.instance.PlaySingle(arrowBreakClip);
		}
	}
}
