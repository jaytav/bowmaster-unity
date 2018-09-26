using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCheck : MonoBehaviour {

	void OnTriggerExit2D(Collider2D col) {
		StartCoroutine(EdgeWait());
		EnemyMovement.direction *= -1f;
	}

	IEnumerator EdgeWait() {
		EnemyMovement.isMoving = false;
		print(EnemyMovement.isMoving);
		yield return new WaitForSeconds(3f);
		EnemyMovement.isMoving = true;
	}
}
