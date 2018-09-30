using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCheck : MonoBehaviour {

	public float waitLength = 2f;
	public EnemyMovement enemyMovement;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Ground") {
			StartCoroutine(WallWait());
			enemyMovement.direction *= -1;
		}
	}

	IEnumerator WallWait() { //stops enemy moving for 3 seconds
		enemyMovement.isMoving = false;
		yield return new WaitForSeconds(waitLength);
		enemyMovement.isMoving = true;
	}
}
