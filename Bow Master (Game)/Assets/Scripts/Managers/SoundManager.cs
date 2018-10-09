using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource musicSource;
	public AudioSource walkingSource;
	public static SoundManager instance = null;

	void Awake() {
		//check if there is an instance of SoundManager, if not set to this
		if (instance == null) instance = this;
		//if an instance does exist, destroy this
		else if (instance != this) Destroy(this);
	}

	public void PlaySingle(AudioClip clip) {
		efxSource.PlayOneShot(clip); //play clip
	}

	public void PlayMoving(AudioClip clip) {
		walkingSource.clip = clip;
		walkingSource.Play();
	}

	public void StopMoving(AudioClip clip) {
		walkingSource.clip = clip;
		walkingSource.Stop();
	}
}
