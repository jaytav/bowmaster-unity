using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour {

	public GameObject[] rooms;

	public float roomHeight;
	public float roomLength;

	private float currentRoomLength;
	
	void Start() {
		currentRoomLength = roomLength/2;

		for (int i = 0; i < rooms.Length; i++) {
			int roomNum = Random.Range(0, rooms.Length);

			Vector2 currentRoomPos = 
				new Vector2(transform.position.x + currentRoomLength,
							transform.position.y + roomHeight);

			Instantiate(rooms[roomNum],
						currentRoomPos,
						transform.rotation);

			currentRoomLength += roomLength;
		}
	}
}
