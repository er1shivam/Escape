using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float speed = 5;
	public float playerPositionWorld;
	public event System.Action OnPlayerDeath;
	// Use this for initialization
	void Start () {
		float halfPlayerWidth  = transform.localScale.x / 2f;
		playerPositionWorld = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;
	}
	
	// Update is called once per frame
	void Update () {

		// float inputX = Input.GetAxis("Mouse X");
		// float velocity = inputX * speed;
		//float velocity = 25f;
		 if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Stationary)
         {
             Vector2 touchPosition = Input.GetTouch(0).position;
             double halfScreen = Screen.width / 2.0;
 
             //Check if it is left or right?
             if(touchPosition.x < halfScreen){
                transform.Translate(Vector3.left * 5 * Time.deltaTime);
             } else if (touchPosition.x > halfScreen) {
                transform.Translate(Vector3.right * 5 * Time.deltaTime);
             }
 
         }



		if(transform.position.x < -playerPositionWorld){
			transform.position = new Vector2 (playerPositionWorld, transform.position.y);
		}
		if(transform.position.x > playerPositionWorld){
			transform.position = new Vector2 (-playerPositionWorld, transform.position.y);
		}

	}

	void OnTriggerEnter2D(Collider2D triggerCollider){
		if(triggerCollider.tag == "Falling Block"){
			if(OnPlayerDeath != null){
				OnPlayerDeath();
			}
			Destroy (gameObject);
		}
	}
}
