using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject currency;
	public float waitTime = 1f;

	public void DropCurrency(int amount) {
		StartCoroutine(waitForNextDrop(amount));
	}

	IEnumerator waitForNextDrop(int amount) {
		for (int i = 0; i < amount; i++) {
			Instantiate(currency, transform.position, transform.rotation);
			yield return new WaitForSeconds(waitTime);
		}
	}
}
