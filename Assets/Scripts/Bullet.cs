using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "Enemy") {
			Destroy(other.gameObject);
		} else {
			Destroy(this);
		}
	}
}
