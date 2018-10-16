using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
	public float speed = 500f;
	public float reduceSpeed = 0.05f;
	public Object brokenArrow;
	public AudioClip arrowBreakAudio;
	
	private Vector2 directionToMouse;
	private int damage;
	private float chargePower;
	private Rigidbody2D arrowRB;
	private SpriteRenderer arrowSpriteRenderer;

	void Awake()
	{
		damage = PlayerShooting.damage; //set arrows damage
		chargePower = PlayerShooting.chargeTime; //get charge amount
	}

	void Start()
	{
		arrowRB = GetComponent<Rigidbody2D>();
		arrowSpriteRenderer = GetComponent<SpriteRenderer>();

		SetDirection();
	}

	void Update() {
		transform.Translate(directionToMouse.x * Time.deltaTime * speed,
							directionToMouse.y * Time.deltaTime * speed,
							0f,
							Space.World);
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		if (col.tag == "PlayerRange") { //ignores collision inside player range
			return;
		}
		print(col.name);
		DestroyInstantiateArrow();

		if (col.tag == "Enemy" && chargePower >= 1f) {
			EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
			enemyHealth.TakeDamage(damage);
		}

		if (col.tag == "Boss" && chargePower >= 1f) {
			BossHealth bossHealth = col.gameObject.GetComponent<BossHealth>();
			bossHealth.TakeDamage(damage);
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerRange") { //destroy arrow when
			DestroyInstantiateArrow();
		}
	}

	void DestroyInstantiateArrow() {
		Destroy(gameObject);
		SoundManager.instance.PlaySingle(arrowBreakAudio);
		Instantiate(brokenArrow, transform.position, transform.rotation); //broken arrow takes place of destroyed arrow
	}

	void SetDirection() { //get arrow and mouse positions, then calculate direction
		Vector2 arrowPos = transform.position;
		Vector2 mousePoint = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
		directionToMouse = mousePoint - arrowPos;
	}

}
