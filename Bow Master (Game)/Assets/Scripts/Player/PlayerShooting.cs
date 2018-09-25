using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
	public static float chargeTime = 0f; //how long the player has charged the bow
	public static float damage = 5f;
	public GameObject arrow; //arrow being spawned

	const float maxCharge = 1f; //maximum charge time

	private Transform arrowSpawn;

	void Start()
	{
		arrowSpawn = transform;
	}

	void Update()
	{
		if (Input.GetButton("Fire1"))
		{
			//increase charge time based on time held
			chargeTime += Time.deltaTime;
			
			//limit maximum charge time to 1 second
			if (chargeTime > maxCharge) { chargeTime = maxCharge; }
		}

		if (Input.GetButtonUp("Fire1"))
		{	
			//create an instance of the arrow, located on arrowSpawn
			Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation);
			chargeTime = 0f; //reset charge time back to 0
		}
	}
}
