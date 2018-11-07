using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour {

	public static Quaternion lastRotation;
	public float smoothSpeed;

	private Quaternion defaultRotation;

	void Awake() {
		defaultRotation = Quaternion.Euler(0f, 0f, 0f); //set default rotation
	}

     void Update() {
		Vector2 playerPos = Camera.main.WorldToViewportPoint (transform.position); //get player position
		Vector2 mousePos = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition); //get mouse position
		
		//rotate player on z-axis
		Quaternion rotation = Quaternion.Euler(new Vector3(
			0f,
			0f,
			Mathf.Atan2(playerPos.y - mousePos.y, playerPos.x - mousePos.x) * Mathf.Rad2Deg));
			
		transform.rotation = Quaternion.Slerp(lastRotation, rotation, Time.deltaTime * smoothSpeed);
		lastRotation = transform.rotation;
	}
}
