using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(AudioDistortionFilter))]
public class AudioPlayer : MonoBehaviour {

	private void Start() {
		GetComponent<AudioSource>().Play();
	}
	
	private void Update() {
		float pixelLevel = GameState.Instance.PixelLevel;
		GetComponent<AudioSource>().volume = Mathf.Min(0.1f + 0.05f * pixelLevel / 16.0f, 1.0f);
		GetComponent<AudioDistortionFilter>().distortionLevel = Mathf.Clamp((1.0f - 0.01f * (pixelLevel / 12.0f)), 0.0f, 1.0f);
	}
}
