using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	private float _timeToLive;
	private float _currentTime;

	private bool _startClicked;

	private void Start() {
		_timeToLive = 5.0f;
		_currentTime = 0.0f;
		_startClicked = false;

		GameObject.Find("Message").SetActive(false);
		GameObject.Find("Message2").SetActive(false);
	}

	public void PlayButtonClick() {
		// GameObject.Find("Message").SetActive(true);
		// GameObject.Find("Message2").SetActive(true);

		Destroy(GameObject.Find("Title"));
		Destroy(GameObject.Find("PlayButton"));
		Destroy(GameObject.Find("Instructions"));

		_startClicked = true;

		GameState.Instance.StartGame();
	}

	private void Update() {
		if (Input.GetButton("R")) {
			GameState.Instance.Restart();
		}

		if (Input.GetKey("escape")) {
			GameState.Instance.Restart();
		}

		if (_startClicked) {
			_currentTime += Time.deltaTime;
			if (_currentTime >= _timeToLive) {
				Destroy(GameObject.Find("Message"));
				Destroy(GameObject.Find("Message2"));
			}	
		}
	}

}
