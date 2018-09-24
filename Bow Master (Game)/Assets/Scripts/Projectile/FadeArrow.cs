using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeArrow : MonoBehaviour
{
	//bool to wait before beginning fade
	private bool startFade = false;
	//color to set the object to
	private Color alphaColor;
	//speed of fade
	private float timeToFade = 2f;
	//pushing arrow force
	private float pushForce = 10f;

	private ParticleSystem brokenArrowPS;
	private SpriteRenderer brokenArrowSR;
	private Rigidbody2D brokenArrowRB;

	void Start () {
		brokenArrowPS = GetComponent<ParticleSystem>();
		brokenArrowSR = GetComponent<SpriteRenderer>();
		brokenArrowRB = GetComponent<Rigidbody2D>();

		brokenArrowRB.AddForce(transform.up * pushForce);
		//set color target to be full rgb, 0 alpha
		alphaColor = new Color(255, 255, 255, 0);
		//perform start fade function
		StartCoroutine(StartFade());	
	}

	void Update()
	{
		if (startFade)
		{
			//lowers alpha at a speed of timeToFade until it reaches alphaColor target
			brokenArrowSR.color = Color.Lerp(brokenArrowSR.color, alphaColor, timeToFade * Time.deltaTime);
			//fade arrow particle system starts
			if (!brokenArrowPS.isPlaying) brokenArrowPS.Play();
		}
	}

	IEnumerator StartFade()
	{
		//wait 1 second before starting fade
		yield return new WaitForSeconds(1f);
		startFade = true;
	}
}
