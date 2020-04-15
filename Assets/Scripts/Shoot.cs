using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject bullet;

	private float _timeToNextShoot;

	private void Start() {
		// _timeToNextShoot = 2.0f
	}

	private void Update() {
		if (Input.GetMouseButtonDown(0)) {
			Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40);
			mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

			GameObject bulletObject = GameObject.Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
			bulletObject.transform.LookAt(mousePosition);

			bulletObject.GetComponent<Rigidbody>().AddForce(bulletObject.transform.forward * 1000);
		}
	}

}
