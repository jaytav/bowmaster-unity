using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchScreenController : MonoBehaviour {
	
	public GameObject player;

	private Animator launchScreenAnim;
	private float timeToSpawnPlayer = 2f;
	private float timer;
	private bool goingToMenu;

	void Start() {
		timer = 0f;
		goingToMenu = false;
		launchScreenAnim = GetComponent<Animator>();
		SoundManager.instance.ChangeMusic();
	}

	void Update() {
		if (Input.anyKey) {
			goingToMenu = true;
			launchScreenAnim.SetTrigger("GoToMenu");
		}

		if (goingToMenu) {
			timer += Time.deltaTime;
			if (timer >= timeToSpawnPlayer) {
				player.SetActive(true);
			}
		}
	}
}
