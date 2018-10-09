using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public static float moveHorizontal;
	public static int direction = 1; //what direction player is facing 1 or -1
	public float speed = 5f;
	public float jumpPower = 300f;
	public float jumpWait;
	public AudioClip moveAudio;

	private Rigidbody2D playerRB;
	private SpriteRenderer playerSR;
	private GameObject background;
	private BackgroundController backgroundController;
	private bool jumped;
	private bool isMoving;
	
	void Awake()
	{
		playerRB = GetComponent<Rigidbody2D>();
		playerSR = GetComponent<SpriteRenderer>();
	}

	void Start() {
		background = GameObject.FindGameObjectWithTag("Background");

		if (background) { 
			backgroundController = background.GetComponent<BackgroundController>();
		}
	}

	void Update()
	{
		moveHorizontal = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		
		transform.Translate(moveHorizontal, 0, 0); //horizontal movement

		if (GroundCheck.grounded && !isMoving) {
			if (Mathf.Abs(moveHorizontal) > 0f) {
				SoundManager.instance.PlayMoving(moveAudio);
				isMoving = true;
			}
		}

		if (isMoving) {
			if (Mathf.Abs(moveHorizontal) == 0f || !GroundCheck.grounded) {
				SoundManager.instance.StopMoving(moveAudio);
				isMoving = false;
			}
		}
		
		if (Input.GetButtonUp("Jump") && GroundCheck.grounded && !jumped)
		{
			jumped = true;
			StartCoroutine(waitJump());
		}
		Flip(moveHorizontal);
	}

	void Flip(float h) //flips player sprite based on horziontal direction
	{
		if (h > 0) { playerSR.flipX = false; direction = 1; } //sprite faces forward
		if (h < 0) { playerSR.flipX = true; direction = -1; } //sprite faces backwards
	}

	IEnumerator waitJump() {
		yield return new WaitForSeconds(jumpWait);
		playerRB.AddForce(Vector2.up * jumpPower); //jumps
		//wait 1 second before being able to jump again
		yield return new WaitForSeconds(jumpWait * 5); 
		jumped = false;
	}

	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Store") {
			backgroundController.ChangeBackgroundStore();
		}

		if (col.tag == "BossRoom") {
			backgroundController.ChangeBackgroundBoss();
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Store" || col.tag == "BossRoom") {
			backgroundController.ChangeBackgroundDefault();
		}
	}
}
