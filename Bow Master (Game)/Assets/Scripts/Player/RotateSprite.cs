using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour {

	public float smoothSpeed;

	private Quaternion defaultRotation;

	void Awake() {
		defaultRotation = Quaternion.Euler(0f, 0f, 0f); //set default rotation
	}

     void Update() {
		 //only rotate player if they are charging
         if (PlayerShooting.chargeTime > 0f) {
			Vector2 playerPos = Camera.main.WorldToViewportPoint (transform.position); //get player position
			Vector2 mousePos = (Vector2)Camera.main.ScreenToViewportPoint(Input.mousePosition); //get mouse position
			
			//rotate player on z-axis
			transform.rotation = Quaternion.Euler(new Vector3(
				0f,
				0f,
				Mathf.Atan2(playerPos.y - mousePos.y, playerPos.x - mousePos.x) * Mathf.Rad2Deg));
		 }
		 else transform.rotation = Quaternion.Slerp(transform.rotation, defaultRotation, Time.deltaTime * smoothSpeed); //smoothly rotate back to normal
	}
}
