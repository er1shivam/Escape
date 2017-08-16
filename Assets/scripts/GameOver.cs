using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

	public GameObject gameOverScreen;
	public Text secondsSurvivedUI;
	bool gameOver;

	void Start() {
		gameOverScreen.SetActive (false);
		FindObjectOfType<PlayerControl> ().OnPlayerDeath += OnGameOver;
	}

	void Update () {
		if (gameOver) {
			// if (Input.touchCount > 0) {
				
			// 	SceneManager.LoadScene (0);
			// }
		}
	}
	
	void OnGameOver() {
		gameOverScreen.SetActive (true);
		secondsSurvivedUI.text = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
		gameOver = true;
	}
}