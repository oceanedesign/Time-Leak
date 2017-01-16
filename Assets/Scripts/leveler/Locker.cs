using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Locker : MonoBehaviour {

	public List<GameObject> objectForUnlock;
	public float timeLockedText = 1f;
	public string messageToDisplay = "Il me reste des choses à faire ici...";
	// Scripts blocable
	public enum scriptName{ Interact, EndGame };
	public scriptName scriptN;

	// Prive
	bool playerInZone, objectInView, textVisible = false;
	float timeTextVisible;
	string tmpString;

	// Use this for initialization
	void Start () {
		switch (scriptN) {	// Choisi le script a desactiver
			case scriptName.Interact:
				GetComponent<Interact> ().enabled = false;
			break;

			case scriptName.EndGame:
				GetComponent<EndGame> ().enabled = false;
			break;
		}
		// Debug init
		timeTextVisible = -1;
	}
	
	// Update is called once per frame
	void Update () {
		// S'il n'y a plus de GO dans la liste
		if (objectForUnlock.Count == 0) {
			switch (scriptN) {
				case scriptName.Interact:
					GetComponent<Interact> ().enabled = true;
					break;

				case scriptName.EndGame:
					GetComponent<EndGame> ().enabled = true;
					break;
			}
			Destroy (this);	// Detruit le script
		}

		// Verifie si un GO de la liste n'a pas ete detruit dans la scene
		for(var i = objectForUnlock.Count - 1; i > -1; i--)
		{
			if (objectForUnlock[i] == null)	
				objectForUnlock.RemoveAt(i);	// Si oui, retire le GO de la liste
		}

		// Meme script que dans Interact -> Si l'objet est dans la zone d'interaction du joueur
		if ( PlayerObjectInteract.isObjectInPlayerInteractiveZone( gameObject.GetComponent<Collider>() ) ){ objectInView = true; } else { objectInView = false; }

		//Le joueur tente d'interagir avec le GO bloque
		if( playerInZone && Input.GetButton("Interact") && objectInView && timeTextVisible < 0){
			// Remplace temporairement le message par le warning/message tampon
			tmpString = GameObject.Find ("lockedText").GetComponent<Text> ().text;
			GameObject.Find ("lockedText").GetComponent<Text> ().text = messageToDisplay;

			// Active le timer
			textVisible = true;
			timeTextVisible = timeLockedText;
		}

		//	Timer
		if (textVisible) {	// Si le timer est actif
			if (timeTextVisible < 0){ // Si le timer est fini
				//Remet le texte initial
				GameObject.Find ("lockedText").GetComponent<Text> ().text = tmpString;
				// Desactive le timer
				textVisible = false;
			} else {	// Sinon decremente le timer
				timeTextVisible -= Time.deltaTime;
			}
		}
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {
			playerInZone = true;
		}
	}

	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other){
		if (other.gameObject.tag == "Player") {
			playerInZone = false;
		}
	}
}
