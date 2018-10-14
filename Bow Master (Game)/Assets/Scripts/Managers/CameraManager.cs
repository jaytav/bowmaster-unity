using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public static CameraManager instance = null;
	public Transform playerTransform;
	
	public float speed;
	public float smoothSpeed = 0.125f;
	public float defaultZoom = 12f;
	public float dampTime;
	public float velocity;

	private Vector2 startPos;
	private Vector2 targetPos;
	private Vector2 directionToTarget;

	private float lerpElapsed = 0f;
	private float lerpDuration = 1f;
	private float prevZoom;
	private float targetZoom;
	private Transform target;

	void Start() {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		
		if (player) { 
			playerTransform = player.transform; 
			target = playerTransform; 
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
		lerpElapsed += Time.deltaTime / lerpDuration;
		Camera.main.orthographicSize = Mathf.Lerp(prevZoom, targetZoom, lerpElapsed);
	}

	void LateUpdate() {

		Vector3 targetPos = target.transform.position;
		float mouseX = Input.mousePosition.x / Screen.width;
		float mouseY = Input.mousePosition.y / Screen.height;
		transform.position = new Vector3(mouseX + targetPos.x, mouseY + targetPos.y, -10);

		/* 

		float maxScreenPoint = 0.8f;
 Vector3 mousePos = Input.mousePosition * maxScreenPoint    + new Vector3(Screen.width, Screen.height, 0f) * ((1f - maxScreenPoint) * 0.5f);
 //Vector3 position = (target.position + GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition)) / 2f;
 Vector3 position = (target.position + GetComponent<Camera>().ScreenToWorldPoint(mousePos)) / 2f;
 Vector3 destination = new Vector3(position.x, position.y, -10);
 transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);

		float mouseX = (Input.mousePosition.x / (Screen.width * 1.2f));
		float mouseY = (Input.mousePosition.y / (Screen.width * 1.2f));

		startPos = transform.position;
		targetPos = 
			new Vector2(target.position.x + mouseX,
						target.position.y + mouseY);
		directionToTarget = targetPos - startPos;

		float distance = Vector2.Distance(targetPos, transform.position);

		transform.Translate((directionToTarget.x * (speed - distance/10) * Time.deltaTime),
							(directionToTarget.y * (speed - distance/10) * Time.deltaTime),
							0f);
		*/
		// if (target) {
		// 	Vector3 desiredPosition = target.position + offset;
		// 	transform.position = desiredPosition;
		// }
	
	}

	public void CameraZoom(float targZoom) {
		lerpElapsed = 0f;
		prevZoom = Camera.main.orthographicSize;
		targetZoom = targZoom;
	}

	public void ChangeTarget(Transform targTransform) {
		target = targTransform;
	}
}
