using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {

	public float speed;
	public bool isFollowing;
	public GameObject kingSlime;

	private Rigidbody2D kingSlimeRB;

	private GameObject player; //player object
	private Vector2 startPos;
	private Vector2 targetPos;
	private Vector2 directionToTarget;
	
	void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		isFollowing = true;

		if (kingSlime) {
			kingSlimeRB = GetComponent<Rigidbody2D>();
		}
	}
	
	void Update() {
		if (isFollowing) {
			startPos = transform.position; //get currency current position
			targetPos = player.transform.position; //get player current position
			directionToTarget = targetPos - startPos; //calculate direction from currency to player

			//move currency smoothly towards player, moves faster the closer currency is to the player
			transform.Translate((directionToTarget.x * Time.deltaTime * speed),
								(directionToTarget.y * Time.deltaTime * speed),
								0f);
		}

		if (Mathf.Abs(kingSlimeRB.velocity.x) > .1f || Mathf.Abs(kingSlimeRB.velocity.y) > .1f) {
			isFollowing = false;
		}	else isFollowing = true;
	}
}
