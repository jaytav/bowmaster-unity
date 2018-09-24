using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
	//variable for if player is on ground or not
	public static bool grounded;

	//if Ground Check trigger touches something, the player is grounded
	void OnTriggerEnter2D(Collider2D col)
	{
		grounded = true; //sets grounded true
	}

	void OnTriggerStay2D(Collider2D col) {
		grounded = true;
	}

	//if Ground Check trigger leaves something, the player is not grounded
	void OnTriggerExit2D(Collider2D col)
	{
		grounded = false; //sets grounded false
	}
}
