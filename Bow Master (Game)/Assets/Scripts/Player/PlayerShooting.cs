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
	public float arrowRegenTime;
	public int totalArrows;

	const float maxCharge = 1f; //maximum charge time

	
	public int currentArrows;
	public float arrowRegenTimer;

	private Transform arrowSpawn;
	private GameObject playerRange;
	private CircleCollider2D playerRangeCol;
	private ParticleSystem playerRangePS;
	private ParticleSystem.ShapeModule playerRangePSSM;

	void Start()
	{
		damage = damageInspector;
		currentArrows = totalArrows;
		playerRange = GameObject.FindGameObjectWithTag("PlayerRange");
		playerRangeCol = playerRange.GetComponent<CircleCollider2D>();
		playerRangePS = playerRange.GetComponent<ParticleSystem>();
		playerRangePSSM = playerRangePS.shape;

		arrowSpawn = transform;
	}

	void Update()
	{
		RangeChange();

		if (currentArrows < totalArrows) {
			arrowRegenTimer += Time.deltaTime;
		}

		if (arrowRegenTimer >= arrowRegenTime) {
			arrowRegenTimer = 0f;
			currentArrows++;
		}

		if (Input.GetButtonUp("Fire1") && currentArrows > 0)
		{
			Instantiate(arrow, arrowSpawn.position, PlayerRotate.lastRotation);
			currentArrows--;
			SoundManager.instance.PlaySingle(shootAudio);
		}
	}

	void RangeChange() {
		playerRangeCol.radius = range;
		playerRangePSSM.radius = range;
	}
}
