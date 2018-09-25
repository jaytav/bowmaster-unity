using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChargeBar : MonoBehaviour {

	private Image chargeBar;

	void Awake() {
		chargeBar = GetComponent<Image>();
	}

	void Update() {
		chargeBar.fillAmount = PlayerShooting.chargeTime;
	}
}
