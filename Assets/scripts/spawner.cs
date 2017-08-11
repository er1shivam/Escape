using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject fallingBlockprefab;
	public float secondsBetweenSpawns = 1;
	float nextSpawntime;
	
	public Vector2 spawnSizeMinMax;

	Vector2 screenHalfsizeWorldUnits;
	// Use this for initialization
	void Start () {
		screenHalfsizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawntime){
			nextSpawntime = Time.time + secondsBetweenSpawns;
			
			float spawnSize = Random.Range(spawnSizeMinMax.x,spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2 (Random.Range(-screenHalfsizeWorldUnits.x,screenHalfsizeWorldUnits.x),screenHalfsizeWorldUnits.y + spawnSize/2f);
			Instantiate(fallingBlockprefab,spawnPosition,Quaternion.identity);

		}
	}
}
