using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
	//References
	private Animator playerAnimator;

	void Awake()
	{
		//references player's Animator
		playerAnimator = GetComponent<Animator>();
	}

	void Update()
	{
		Jumped();
		IsMoving();
		IsCharging();
		Grounded();
	}

	void IsMoving() //checks if player is moving
	{
		//if horizontal axis value is being changed
		if (PlayerMovement.moveHorizontal > 0f || PlayerMovement.moveHorizontal < 0f)
		{
			//sets IsMoving to true
			playerAnimator.SetBool("IsMoving", true);
		}
		else
		{
			//otherwise, sets IsMoving to false
			playerAnimator.SetBool("IsMoving", false);
		}
	}

	void IsCharging() //checks if player is charging
	{
		if (PlayerShooting.chargeTime > 0f) {
			playerAnimator.SetBool("IsCharging", true);
		}
		else playerAnimator.SetBool("IsCharging", false);
	}

	void Jumped() //check if player jumped
	{
		if (Input.GetButtonUp("Jump") && GroundCheck.grounded)
		{
			playerAnimator.SetTrigger("Jumped");
		}
	}

	void Grounded() //checks if player is grounded
	{
		playerAnimator.SetBool("Grounded", GroundCheck.grounded);
	}
}
