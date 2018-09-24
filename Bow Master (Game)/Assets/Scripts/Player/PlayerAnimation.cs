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
		if (PlayerMovement.moveHorizontal > 0 || PlayerMovement.moveHorizontal < 0)
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
		//if left click or ctrl is being held down
		if (Input.GetButton("Fire1"))
		{
			//sets IsCharging to true
			playerAnimator.SetBool("IsCharging", true);
		}
		else if (Input.GetButtonUp("Fire1"))
		{
			//otherwise, sets IsCharging to false
			playerAnimator.SetBool("IsCharging", false);
		}
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
		//checks ground check grounded (public static) for grounded value
		if (GroundCheck.grounded == true)
		{
			//sets Grounded to true
			playerAnimator.SetBool("Grounded", true);
		}
		else if (GroundCheck.grounded == false)
		{
			//sets Grounded to false
			playerAnimator.SetBool("Grounded", false);
		}
	}
}
