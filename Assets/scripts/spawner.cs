using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject fallingBlockprefab;
	public float secondsBetweenSpawns = 1;
	float nextSpawntime;

	Vector2 screenHalfsizeWorldUnits;
	// Use this for initialization
	void Start () {
		screenHalfsizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawntime){
			nextSpawntime = Time.time + secondsBetweenSpawns;
			Vector2 spawnPosition = new Vector2 (Random.Range(-screenHalfsizeWorldUnits.x,screenHalfsizeWorldUnits.x),screenHalfsizeWorldUnits.y);
			Instantiate(fallingBlockprefab,spawnPosition,Quaternion.identity);

		}
	}
}
