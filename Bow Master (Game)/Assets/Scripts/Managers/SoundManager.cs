using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour {

	public AudioClip[] music;

	public AudioSource[] sources;

	public static SoundManager instance = null;

	void Awake() {
		sources = GetComponents<AudioSource>();

		//check if there is an instance of SoundManager, if not set to this
		if (instance == null) instance = this;
		//if an instance does exist, destroy this
		else if (instance != this) Destroy(this);

		ChangeMusic();
		DontDestroyOnLoad(gameObject);
	}

	public void ChangeMusic() {
		sources[0].clip = music[SceneManager.GetActiveScene().buildIndex];
		sources[0].Play();
	}

	public void PlaySingle(AudioClip clip) {
		sources[1].PlayOneShot(clip); //play clip
	}

	public void PlayMoving(AudioClip clip) {
		sources[2].clip = clip;
		sources[2].Play();
	}

	public void StopMoving(AudioClip clip) {
		sources[2].clip = clip;
		sources[2].Stop();
	}
}
