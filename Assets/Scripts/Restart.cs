using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	private void Update() {
		if (Input.GetButton("R")) {
			Debug.Log("RRRRR");
			GameState.Instance.Restart();
		}

		if (Input.GetKey("escape")) {
			Debug.Log("escape");
			GameState.Instance.Restart();
		}
	}
}
