using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private float _viewDistance;
	private RaycastHit _raycastHit;
	private GameObject _player;

	private void Start() {
		_viewDistance = 10.0f;
		_player = GameObject.Find("Player");
	}
	
	private void Update() {
		transform.LookAt(_player.transform);
		if (Physics.Raycast(transform.position, _player.transform.position - transform.position, out _raycastHit, _viewDistance)) {

			Debug.DrawLine(transform.position, _player.transform.position, Color.red);
			Debug.Log(_raycastHit.collider.gameObject);

			if (_raycastHit.collider.gameObject == _player) {
				Debug.Log("I see you!");
			}
		}
	}
}
