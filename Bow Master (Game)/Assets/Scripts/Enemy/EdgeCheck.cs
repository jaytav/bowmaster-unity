using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeCheck : MonoBehaviour {

	public float waitLength = 2f;
	public EnemyMovement enemyMovement;

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "Ground") {
			StartCoroutine(EdgeWait());
			enemyMovement.direction *= -1f;
		}
	}

	IEnumerator EdgeWait() { //stops enemy moving for 3 seconds
		enemyMovement.isMoving = false;
		yield return new WaitForSeconds(waitLength);
		enemyMovement.isMoving = true;
	}
}
