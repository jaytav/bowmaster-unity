using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour {

	private Image chargeBar;
	private ParticleSystem chargeBarPS;

	void Awake() {
		chargeBar = GetComponent<Image>();
		chargeBarPS = GetComponent<ParticleSystem>();
	}

	void Update() {
		chargeBar.fillAmount = PlayerShooting.chargeTime;
		
		if (PlayerShooting.chargeTime > 0f) {
			if (!chargeBarPS.isPlaying) { chargeBarPS.Play(); }
		}
		else if (chargeBarPS.isPlaying) { chargeBarPS.Stop(); }
	}
}
