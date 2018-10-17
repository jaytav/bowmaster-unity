using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFlash : MonoBehaviour {

	public float flashRate;
	public float flashLength;
	public Color flashColor;

	private Color normalColor;
	public Text uiText;
	private float counter;

	void Start() {
		uiText = GetComponent<Text>();
		if (uiText) { normalColor = uiText.color; }
	}

	void Update() {
		counter += Time.deltaTime;

		if (counter > flashRate) {
			StartCoroutine(WaitForFlash());
		}
	}

	IEnumerator WaitForFlash() {
		uiText.color = flashColor;
		yield return new WaitForSeconds(flashLength);
		uiText.color = normalColor;
		counter = 0f;
	}
}
