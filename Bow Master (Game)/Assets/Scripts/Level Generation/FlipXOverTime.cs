using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipXOverTime : MonoBehaviour {

	public float waitTime;

	private float time;
	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	void Update() {
		time += Time.deltaTime;

		if (time > waitTime) {
			FlipX();
			time = 0f;
		}
	}

	void FlipX() {
		if (spriteRenderer.flipX) {
			spriteRenderer.flipX = false;
		}
		else spriteRenderer.flipX = true;
	}
}
