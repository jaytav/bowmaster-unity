using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public AudioSource efxSource;
	public AudioSource musicSource;
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
}
