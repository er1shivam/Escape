using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 7;
	public float playerPositionWorld;
	// Use this for initialization
	void Start () {
		float halfPlayerWidth  = transform.localScale.x / 2f;
		playerPositionWorld = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
	}
	
	// Update is called once per frame
	void Update () {

		float inputX = Input.GetAxisRaw("Horizontal");
		float velocity = inputX * speed;
		transform.Translate (Vector2.right*velocity* Time.deltaTime);

		if(transform.position.x < -playerPositionWorld){
			transform.position = new Vector2 (playerPositionWorld, transform.position.y);
		}
		if(transform.position.x > playerPositionWorld){
			transform.position = new Vector2 (-playerPositionWorld, transform.position.y);
		}


	}

	void OnTriggerEnter2D(Collider2D triggerCollider){
		if(triggerCollider.tag == "Falling Block"){
			Destroy (gameObject);
		}
	}
}
