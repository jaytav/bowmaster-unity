using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour {

	public GameObject[] rooms;
	public GameObject spawn;
	public GameObject store;
	public GameObject tunnel;
	public GameObject bossRoom;

	public float roomHeight;
	public float roomLength;

	private float currentRoomLength;
	private Vector2 currentRoomPos;
	
	void Start() {
		currentRoomLength = roomLength/2;

		SpawnSpawnRoom();

		for (int i = 0; i < rooms.Length; i++) {
			int roomNum = Random.Range(0, rooms.Length);

			SpawnEnemyRoom(roomNum);
			SpawnTunnelRoom();
			SpawnStoreRoom();			
			SpawnTunnelRoom();
		}

		SpawnBossRoom();
	}

	void SpawnSpawnRoom() {
		currentRoomPos = //position of room
				new Vector2(transform.position.x + currentRoomLength,
							transform.position.y + roomHeight);

		Instantiate(spawn, //spawn spawn room
					currentRoomPos, 
					transform.rotation,
					gameObject.transform);

		currentRoomLength += roomLength; //increment length for next room
	}

	void SpawnEnemyRoom(int roomNum) {
		currentRoomPos = //position of room
			new Vector2(transform.position.x + currentRoomLength,
						transform.position.y + roomHeight);

		Instantiate(rooms[roomNum], //spawn room
					currentRoomPos,
					transform.rotation,
					gameObject.transform);

		currentRoomLength += roomLength; //increment length for next room
	}

	void SpawnTunnelRoom() {
		currentRoomPos = //position of tunnel
			new Vector2(transform.position.x + currentRoomLength,
						transform.position.y + roomHeight);

		Instantiate(tunnel, //spawn tunnel
					currentRoomPos, 
					transform.rotation,
					gameObject.transform);

		currentRoomLength += roomLength; //increment length for next room
	}

	void SpawnStoreRoom() {
		currentRoomPos = //position of store
			new Vector2(transform.position.x + currentRoomLength,
						transform.position.y + roomHeight);

		Instantiate(store, //spawn store
					currentRoomPos, 
					transform.rotation,
					gameObject.transform);

		currentRoomLength += roomLength; //increment length for next room
	}

	void SpawnBossRoom() {
		currentRoomPos = //position of store
			new Vector2(transform.position.x + currentRoomLength,
						transform.position.y + roomHeight);

		Instantiate(bossRoom,
					currentRoomPos,
					transform.rotation,
					gameObject.transform);
	}
}
