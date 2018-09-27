using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFadeAndDestroy : MonoBehaviour {

	public float fadeTime = 3f;

	private SpriteRenderer enemySR;
	private Color currentColor;
	private Color fadeColor = Color.white;
	private float t = 0f;

	private ParticleSystem enemyPS;
	
	void Start() {
		enemySR = GetComponent<SpriteRenderer>();
		enemyPS = GetComponent<ParticleSystem>();
		currentColor = enemySR.color;
		fadeColor.a = 0f;

		StartCoroutine(WaitPS());
		StartCoroutine(WaitDestroy());
	}

	void Update() {
		if (t < fadeTime) {
			enemySR.color = Color.Lerp(currentColor, fadeColor, t);
			t += Time.deltaTime / fadeTime;
		}
		
	}

	IEnumerator WaitDestroy() {
		yield return new WaitForSeconds(fadeTime * 2f);
		Destroy(gameObject);
	}

	IEnumerator WaitPS() {
		if (!enemyPS.isPlaying) { enemyPS.Play(); }
		yield return new WaitForSeconds(fadeTime);
		if (enemyPS.isPlaying) { enemyPS.Stop(); }
	}
}
