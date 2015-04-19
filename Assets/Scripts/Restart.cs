using UnityEngine;
using System.Collections;

public class Restart : MonoBehaviour {

	private void Start() {
		Application.LoadLevel("GameScene");
	}
}
