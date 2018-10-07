using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
	public float speed = 500f;
	public float reduceSpeed = 0.05f;
	public Object brokenArrow;

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

		//flip arrow sprite based on player's direction
		if (PlayerMovement.direction == -1) { arrowSpriteRenderer.flipX = true; }
		
		arrowRB.AddForce(Vector2.up * speed * reduceSpeed); //push arrow up a bit

		//launch arrow forward
		if (chargePower >= 1f) {
			arrowRB.AddForce(Vector2.right * PlayerMovement.direction * speed * chargePower); //power shot
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{	
		if (col.tag == "PlayerRange") { //ignores collision inside player range
			return;
		}
		DestroyInstantiateArrow();

		if (col.tag == "Enemy" && chargePower >= 1f) {
			EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
			enemyHealth.TakeDamage(damage);
		}

		if (col.tag == "Boss" && chargePower >= 1f) {
			BossHealth bossHealth = col.gameObject.GetComponent<BossHealth>();
			bossHealth.TakeDamage(damage);
			print("Hit boss lol");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "PlayerRange") { //destroy arrow when
			DestroyInstantiateArrow();
		}
	}

	void DestroyInstantiateArrow() {
		Destroy(gameObject);
		Instantiate(brokenArrow, transform.position, Quaternion.Euler(0f, 0f, Random.Range(-45f, 45f))); //broken arrow takes place of destroyed arrow
	}

}
