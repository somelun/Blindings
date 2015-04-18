using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	private float _viewDistance;
	private RaycastHit _raycastHit;
	private GameObject _player;
	private float _moveSpeed;

	private void Start() {
		_moveSpeed = 1.0f;
		_viewDistance = 10.0f;
		_player = GameObject.Find("Player");
	}
	
	private void Update() {
		Vector3 playerDirection = _player.transform.position - this.transform.position;
		if (Physics.Raycast(this.transform.position, playerDirection, out _raycastHit, _viewDistance)) {
			if (_raycastHit.collider.gameObject == _player) {
				Vector3 playerPosition = _player.transform.position;
				this.GetComponent<Rigidbody>().velocity = new Vector3(_moveSpeed * playerDirection.x, 0, _moveSpeed * playerDirection.z);
			}
		}
	}
}
