using UnityEngine;
using System.Collections;

public class MenuButtons : MonoBehaviour {

	public void PlayButtonClick() {
		Destroy(GameObject.Find("Title"));
		Destroy(GameObject.Find("PlayButton"));
		Destroy(GameObject.Find("Instructions"));

		GameState.Instance.StartGame();
	}
}
