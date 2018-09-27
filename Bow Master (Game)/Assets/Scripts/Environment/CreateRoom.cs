using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRoom : MonoBehaviour {

	public int width;
	public int height;

	public float bricksDistanceX = 0.75f;
	public float brickDistanceY = 0.5f;

	public Sprite[] brickSprites;
	public GameObject[] platforms;

	private GameObject brick;
	private int randomBrickNum;
	private SpriteRenderer brickSR;

	void Start () {
		for (float i = 0; i < height; i += brickDistanceY) {
			for (float y = 0; y < width; y += bricksDistanceX) {
				brick = new GameObject();
				randomBrickNum = Random.Range(0, brickSprites.Length - 1);
				brickSR = brick.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
				brickSR.sprite = brickSprites[randomBrickNum];

				Vector3 brickNewPos = new Vector3(y, i, 0f);

				Instantiate(brick, transform.position + brickNewPos, transform.rotation);
			}
		}
	}
}
