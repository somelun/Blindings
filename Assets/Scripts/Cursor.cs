using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {

	public Texture2D cursorImage;

	private void Start() {
    	UnityEngine.Cursor.visible = false;
	}
	
	private void OnGUI() {
    	Vector3 mousePosition = Input.mousePosition;
    	GUI.DrawTexture(new Rect(mousePosition.x, Screen.height - mousePosition.y, 2, 2), cursorImage);
	}
}
