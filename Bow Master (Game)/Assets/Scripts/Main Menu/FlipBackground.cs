using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipBackground : MonoBehaviour {

	public float waitTime;

	private float time;
	private RectTransform backgroundRT;

	void Start() {
		backgroundRT = GetComponent<RectTransform>();
	}

	void Update() {
		time += Time.deltaTime;

		if (time > waitTime) {
			backgroundRT.Rotate(0f, 180f, 0f);
			time = 0f;
		}
	}
}
