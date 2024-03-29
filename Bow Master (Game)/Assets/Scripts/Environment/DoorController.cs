﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

	public float waitTime;
	public BoxCollider2D doorCol;
	public AudioClip doorAudio;

	private bool isOpened;
	private Animator doorAnim;
	private BoxCollider2D doorTrigger;

	void Start() {
		isOpened = false; //door spawns closed
		doorAnim = GetComponent<Animator>();
		doorTrigger = GetComponent<BoxCollider2D>();
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Player" || col.tag == "Projectile") {
			isOpened = true;
			SoundManager.instance.PlaySingle(doorAudio);
			doorAnim.SetBool("IsOpened", isOpened);
			StartCoroutine(WaitDoorOpen());
		}
	}

	IEnumerator WaitDoorOpen() {
		yield return new WaitForSeconds(waitTime);
		doorCol.enabled = false;
		doorTrigger.enabled = false;
	}
}
