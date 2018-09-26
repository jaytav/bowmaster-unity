using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateNumberOfPlatforms : MonoBehaviour {

	public GameObject[] platformObjects;
	public int yDistance;

	private Transform parentPosition;

	void Start() {
		parentPosition = GetComponent<Transform>();
		parentPosition = parentPosition.transform;

		for (int i = 0; i < platformObjects.Length; i++) {
			int randomNum = Random.Range(0, platformObjects.Length - 1);

			Instantiate(platformObjects[randomNum], 
						new Vector2(parentPosition.position.x, yDistance * i), 
						transform.rotation);
		}
	}
}
