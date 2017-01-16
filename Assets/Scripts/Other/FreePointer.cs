using UnityEngine;
using System.Collections;

/**
 *
 *	Script pour liberer ou bloquer le curseur dans une scene
 *
 **/

public class FreePointer : MonoBehaviour {

	public bool pointeurLibre = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if (pointeurLibre) {	// Libere le curseur
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		} else {	// Bloque le curseur
			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false;
		}

	}
}
