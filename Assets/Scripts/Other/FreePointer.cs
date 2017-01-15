using UnityEngine;
using System.Collections;

public class FreePointer : MonoBehaviour {

	public bool pointeurLibre = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (pointeurLibre) {
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} else {
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

	}
}
