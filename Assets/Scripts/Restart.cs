using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	private void Update() {
		if (Input.GetButton("R")) {
			GameState.Instance.Restart();
		}

		if (Input.GetKey("escape")) {
			GameState.Instance.Restart();
		}
	}
}
