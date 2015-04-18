using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioDistortionFilter))]
public class AudioPlayer : MonoBehaviour {

	private void Start() {
		// GetComponent<AudioSource>().Play();
	}
	
	private void Update() {
		if (GameState.Instance.isGasAtomized) {
			//
		}
	}
}
