using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject currency;
	public float waitTime = 1f;

	public void DropCurrency(int amount, Vector2 enemyPos) {
		StartCoroutine(waitForNextDrop(amount, enemyPos));
	}

	IEnumerator waitForNextDrop(int amount, Vector2 enemyPos) {
		for (int i = 0; i < amount; i++) {
			Instantiate(currency, enemyPos, transform.rotation);
			yield return new WaitForSeconds(waitTime);
		}
	}
}
