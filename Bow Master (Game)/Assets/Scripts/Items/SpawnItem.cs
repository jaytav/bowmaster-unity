using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour {

	public GameObject[] items;
	public float height;

	private Vector3 heightUp;

	void Start() {
		heightUp = new Vector3(0f, height, 0f);

		int randomIndex = Random.Range(0, items.Length);

		Instantiate(items[randomIndex],
					transform.position + heightUp,
					transform.rotation,
					gameObject.transform);
	}
}
