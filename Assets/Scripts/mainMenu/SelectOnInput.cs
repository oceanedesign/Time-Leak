using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SelectOnInput : MonoBehaviour {

	public EventSystem eventSystem;
	public GameObject selectedObject;
	private bool buttonSelected;

	// Update is called once per frame
	void Update () 
	// dans le cas où le joueur n'a pas de souris, permet de selectionner les boutons avec les fleches
	{
		if (Input.GetAxisRaw ("Vertical") != 0 && buttonSelected == false) 
		{
			eventSystem.SetSelectedGameObject (selectedObject);
			buttonSelected = true;
		}
	}

	private void onDisable()
	{
		buttonSelected = false;
	}
}
