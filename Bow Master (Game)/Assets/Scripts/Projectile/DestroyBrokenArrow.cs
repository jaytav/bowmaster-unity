using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrokenArrow : MonoBehaviour
{
	//time for the object to be destroyed
	public float timeToDestroy = 5f;

	void Start()
	{
		//delete broken arrows after a certain amount of time
		Destroy(gameObject, timeToDestroy);
		
	}
}
