using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;

	public float smoothSpeed = 0.125f;
	public Vector3 offset;

	void LateUpdate() {
		if (target) {
			Vector3 desiredPosition = target.position + offset;
			transform.position = desiredPosition;
		}
	}
}
