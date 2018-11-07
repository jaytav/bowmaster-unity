using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
	public SpriteRenderer playerSR;
	public static float moveHorizontal;
	public static int direction = 1; //what direction player is facing 1 or -1
	public int inspectorDirection;
	public float speed = 5f;
	public float jumpPower = 300f;
	public float jumpWait;
	public AudioClip moveAudio;
	public Animator backgroundAnim;

	private Rigidbody2D playerRB;
	private GameObject background;
	private BackgroundController backgroundController;
	private bool jumped;
	private bool isMoving;
	private GameObject bossSpawnTrigger;
	
	void Awake()
	{
		playerRB = GetComponent<Rigidbody2D>();
	}

	void Start() {
		background = GameObject.FindGameObjectWithTag("Background");
		bossSpawnTrigger = GameObject.Find("Floor 01/Boss Room(Clone)/Spawn Boss Trigger");

		if (bossSpawnTrigger) {
			print("Found");
		}

		if (background) { 
			backgroundController = background.GetComponent<BackgroundController>();
		}
	}

	void Update()
	{
		inspectorDirection = direction;
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

		if (Input.GetKeyDown(KeyCode.Alpha0)) {
			gameObject.transform.position = bossSpawnTrigger.transform.position;
		}
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
			backgroundAnim.Play("NormalToStore");
		}

		if (col.tag == "BossRoom") {
			backgroundAnim.Play("NormalToBoss");
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.tag == "Store") {
			backgroundAnim.Play("StoreToNormal");
		}

		if (col.tag == "BossRoom") {
			backgroundAnim.Play("BossToNormal");
		}
	}
}
