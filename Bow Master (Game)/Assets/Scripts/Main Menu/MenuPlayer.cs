using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPlayer : MonoBehaviour {

	public Sprite[] playerShootingFrames;
	public Sprite playerModel;
	public float animSpeed;
	public GameObject arrow;
	public AudioClip arrowShoot;

	private Image playerImage;
	private bool isShooting;
	private bool isMoving;
	private Vector3 velocity = Vector3.zero;

	void Start() {
		isMoving = true;
		playerImage = GetComponent<Image>();
	}

	void Update() {
		if (isMoving) {
			// targetPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			// Vector2 followYOnly = new Vector2(transform.position.x, targetPos.y);
			// transform.position = Vector2.Lerp(followYOnly, transform.position, Time.deltaTime);

			Vector2 targetPos = new Vector2(50f, Input.mousePosition.y);
			//mousePos.x = 100;
			transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, 0.1f);
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
		SoundManager.instance.PlaySingle(arrowShoot);
		GameObject newArrow = Instantiate(arrow, transform.position, transform.rotation, gameObject.transform);
		newArrow.transform.SetParent(gameObject.transform.parent);
		isMoving = true;
	}
}