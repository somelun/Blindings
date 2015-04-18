using UnityEngine;
using System.Collections;

public class MoveForFlyingCube : MonoBehaviour {

	private enum MovementDirection {  
		Down = 0, 
		Up = 1
	}

	private float lowY;
	private float highY;
	// priv

	private void Start() {
		lowY = Random.Range(0.0f, 20.0f);
		highY = Random.Range(lowY + 50, 50.0f);
	}
	
	private void Update() {
		//
	}

}
