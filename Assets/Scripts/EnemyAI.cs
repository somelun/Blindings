using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public Transform player;
	public float viewDistance;

	private RaycastHit _raycastHit;

	private void Start() {
		viewDistance = 15.0f;
	}
	
	private void Update() {
		transform.LookAt(player);
		if (Physics.Raycast(transform.position, player.transform.position - transform.position, out _raycastHit, viewDistance)) {
			Debug.DrawLine(transform.position, player.transform.position, Color.red);
			Debug.Log("mek mek mek");
			// if (_raycastHit.collider.gameObject == player) {
			// 	Debug.Log("I see you!");
			// }
		}
	}
}
