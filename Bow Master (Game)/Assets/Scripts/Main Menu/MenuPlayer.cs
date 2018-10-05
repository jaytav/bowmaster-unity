using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayer : MonoBehaviour {

	public Sprite[] playerShootingFrames;
	public Sprite playerModel;
	public float animSpeed;
	public GameObject arrow;

	private Image playerImage;
	private Vector2 targetPos;
	private bool isShooting;
	private bool isMoving;

	void Start() {
		isMoving = true;
		playerImage = GetComponent<Image>();
		targetPos = transform.position;
	}

	void Update() {
		if (isMoving) {
			targetPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			Vector2 followYOnly = new Vector2(transform.position.x, targetPos.y);
			transform.position = Vector2.Lerp(followYOnly, transform.position, Time.deltaTime);
		}
	}

	public void Animate() {
		isMoving = false;
		StartCoroutine(PlayerShootAnim());
	}

	IEnumerator PlayerShootAnim() {
		for (int i = 0; i < playerShootingFrames.Length; i++) {
			playerImage.sprite = playerShootingFrames[i];
			yield return new WaitForSeconds(animSpeed);
		}
		playerImage.sprite = playerModel;
		GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation);
		newArrow.transform.SetParent(gameObject.transform.parent);
		isMoving = true;
	}
}