using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public static CameraManager instance = null;
	public Transform playerTransform;
	public Transform target;
	public Vector3 offset;
	public float speed;
	public float smoothSpeed = 0.01f;
	public float defaultZoom = 12f;
	public float mouseMultiplier;

	private float zoomLerpElapsed = 0f;
	private float zoomLerpDuration = 1f;
	private float prevZoom;
	private float targetZoom;
	private Vector3 velocity = Vector3.zero;

	void Start() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		if (player) { 
			playerTransform = player.transform;
			target = player.transform;
		}

		//check if there is an instance of SoundManager, if not set to this
		if (instance == null) instance = this;
		//if an instance does exist, destroy this
		else if (instance != this) Destroy(this);
		Camera.main.orthographic = true;
		prevZoom = Camera.main.orthographicSize;
		targetZoom = prevZoom;
	}

	void Update() {
		if (target) {
			zoomLerpElapsed += Time.deltaTime / zoomLerpDuration;
			Camera.main.orthographicSize = Mathf.Lerp(prevZoom, targetZoom, zoomLerpElapsed);
		}
	}

	void LateUpdate() {
		if (target) {
			Vector3 mousePos = (Vector3)Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 targetPos = (target.transform.position + mousePos + offset)/2;
			transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.2f);
		}
	}

	public void CameraZoom(float targZoom) {
		zoomLerpElapsed = 0f;
		prevZoom = Camera.main.orthographicSize;
		targetZoom = targZoom;
	}

	public void ChangeTarget(Transform newTransform) {
		target = newTransform;
	}
}
