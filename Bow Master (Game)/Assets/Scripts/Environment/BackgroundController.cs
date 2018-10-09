using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundController : MonoBehaviour {

	public Sprite[] backgroundImages;
	public float slowValue;
	public Color defaultColor;
	public Color storeColor;
	public Color bossColor;
	
	private float lerpValue;
	private Color previousColor;
	private Color currentColor;
	private Image backgroundImage;
	
	private ParticleSystem backgroundParticles;

	void Start() {
		backgroundImage = GetComponentInChildren<Image>();
		backgroundParticles = GetComponentInChildren<ParticleSystem>();
		previousColor = defaultColor;
		currentColor = defaultColor;
	}

	void Update() {
		lerpValue += Time.deltaTime / slowValue;
		backgroundImage.color = Color.Lerp(previousColor, currentColor, lerpValue); //slowly chnage currentColor over time
	}

	public void ChangeBackgroundDefault() { //change background to default
		var textSheetAnim = backgroundParticles.textureSheetAnimation;
		textSheetAnim.enabled = false; //particles change back to normal
		ResetColors();
		currentColor = defaultColor;
	}

	public void ChangeBackgroundStore() { //change background to store
		var textSheetAnim = backgroundParticles.textureSheetAnimation;
		textSheetAnim.enabled = true; //particles change to currency symbol
		ResetColors();
		currentColor = storeColor;
	}

	public void ChangeBackgroundBoss() {
		ResetColors();
		currentColor = bossColor;
		
	}

	void ResetColors() {
		previousColor = currentColor;
		lerpValue = 0f; //reset lerp
	}
}
