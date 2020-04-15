using UnityEngine;
using System.Collections;

public class Exit : MonoBehaviour {
	
	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Player") {
			GameState.Instance.GameOver(true);
		}
	}
}
