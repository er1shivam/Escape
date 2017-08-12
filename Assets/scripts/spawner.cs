using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

	public GameObject fallingBlockprefab;
	public Vector2 secondsBetweenSpawnsMinMax;
	float nextSpawntime;
	
	public Vector2 spawnSizeMinMax;
	public float spawnAngleMax;
	Vector2 screenHalfsizeWorldUnits;
	// Use this for initialization
	void Start () {
		screenHalfsizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize,Camera.main.orthographicSize);
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time > nextSpawntime){
			float secondsBetweenSpawns = Mathf.Lerp(secondsBetweenSpawnsMinMax.y,secondsBetweenSpawnsMinMax.x, difficulty.GetDifficultyPercent());
			nextSpawntime = Time.time + secondsBetweenSpawns;
	
			float spawnAngle = Random.Range(-spawnAngleMax,spawnAngleMax);
			float spawnSize = Random.Range(spawnSizeMinMax.x,spawnSizeMinMax.y);
			Vector2 spawnPosition = new Vector2 (Random.Range(-screenHalfsizeWorldUnits.x,screenHalfsizeWorldUnits.x),screenHalfsizeWorldUnits.y + spawnSize);
			// Building new gameObject to help Scale
			GameObject newBlock = (GameObject)Instantiate(fallingBlockprefab,spawnPosition,Quaternion.Euler(Vector3.forward*spawnAngle));
			newBlock.transform.localScale = Vector2.one * spawnSize;
			
		}
	}

	
}
