using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCheck : MonoBehaviour {

	public float waitLength = 2f;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Ground Edge") {
			StartCoroutine(EdgeWait());
			EnemyMovement.direction *= -1f;
		}
	}

	IEnumerator EdgeWait() { //stops enemy moving for 3 seconds
		EnemyMovement.isMoving = false;
		yield return new WaitForSeconds(waitLength);
		EnemyMovement.isMoving = true;
	}
}
