using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour {

	public GameObject currentInteractable = null;
	private Interactable interactable;

	void Update() {
		if (Input.GetButtonDown("Interact") && currentInteractable) {
			//do something with object
			interactable = currentInteractable.GetComponent<Interactable>();
			interactable.DoEffect();
		}
	}

	void OnTriggerStay2D(Collider2D col) {
		if (col.CompareTag("Interactable")) {
			currentInteractable = col.gameObject;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.CompareTag("Interactable")) {
			if (col.gameObject == currentInteractable) {
				currentInteractable = null;
			}
		}
	}
}
