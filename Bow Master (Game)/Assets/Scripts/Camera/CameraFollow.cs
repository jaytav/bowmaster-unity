using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public float speed;
	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	private Vector2 startPos;
	private Vector2 targetPos;
	private Vector2 directionToTarget;

	void LateUpdate() {
		float mouseX = (Input.mousePosition.x / Screen.width);
		float mouseY = (Input.mousePosition.y / Screen.height);

		startPos = transform.position;
		targetPos = 
			new Vector2(target.position.x + mouseX,
						target.position.y + mouseY);
		directionToTarget = targetPos - startPos;

		float distance = -Vector2.Distance(targetPos, transform.position);

		transform.Translate((directionToTarget.x * (speed - distance/10) * Time.deltaTime),
							(directionToTarget.y * (speed - distance/10) * Time.deltaTime),
							0f);
		
		// if (target) {
		// 	Vector3 desiredPosition = target.position + offset;
		// 	transform.position = desiredPosition;
		// }
	}
}
