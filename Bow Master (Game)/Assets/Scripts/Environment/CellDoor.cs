using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellDoor : MonoBehaviour {

	public float speed;
	public float time;

	private Collider2D cellDoorCol;
	private bool opened = false;

	void Start() {
		cellDoorCol = GetComponent<Collider2D>();
	}

	void Update() {
		if (opened) {
			transform.Translate(0f, speed * Time.deltaTime, 0f);
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			StartCoroutine(OpenClose());
		}
	}

	IEnumerator OpenClose() {
		opened = true;
		yield return new WaitForSeconds(time);
		cellDoorCol.enabled = false;
		opened = false;
	}
}
