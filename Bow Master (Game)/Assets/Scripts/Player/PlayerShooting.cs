using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour
{
	public static float chargeTime = 0f; //how long the player has charged the bow
	public int damageInspector;
	public static int damage;
	public static int range = 6;
	public GameObject arrow; //arrow being spawned
	public AudioClip shootAudio;

	const float maxCharge = 1f; //maximum charge time

	private Transform arrowSpawn;

	private GameObject playerRange;
	private CircleCollider2D playerRangeCol;
	private ParticleSystem playerRangePS;
	private ParticleSystem.ShapeModule playerRangePSSM;

	void Start()
	{
		damage = damageInspector;
		playerRange = GameObject.FindGameObjectWithTag("PlayerRange");
		playerRangeCol = playerRange.GetComponent<CircleCollider2D>();
		playerRangePS = playerRange.GetComponent<ParticleSystem>();
		playerRangePSSM = playerRangePS.shape;

		arrowSpawn = transform;
	}

	void Update()
	{
		RangeChange();

		if (Input.GetButton("Fire1"))
		{
			//increase charge time based on time held
			chargeTime += Time.deltaTime;
			PlayerMovement.direction = -1;
			
			//limit maximum charge time to 1 second
			if (chargeTime > maxCharge) { chargeTime = maxCharge; }
		}

		if (Input.GetButtonUp("Fire1"))
		{	
			//create an instance of the arrow, located on arrowSpawn
			Instantiate(arrow, arrowSpawn.position, arrowSpawn.rotation);
			if (chargeTime >= 1f) {
				SoundManager.instance.PlaySingle(shootAudio);
			}
			chargeTime = 0f; //reset charge time back to 0
		}
	}

	void RangeChange() {
		playerRangeCol.radius = range;
		playerRangePSSM.radius = range;
	}
}
