using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class Locker : MonoBehaviour {

	public List<GameObject> objectForUnlock;
	public float timeLockedText = 1f;
	public string messageToDisplay = "Il me reste des choses à faire ici...";

	bool playerInZone, objectInView, textVisible = false;
	float timeTextVisible;
	string tmpString;

	// Use this for initialization
	void Start () {
		GetComponent<Interact> ().enabled = false;
		timeTextVisible = timeLockedText;
		GameObject.Find ("lockedText").GetComponent<Text> ().enabled = false;
		timeTextVisible = -1;
	}
	
	// Update is called once per frame
	void Update () {
		if (objectForUnlock.Count == 0) {
			GetComponent<Interact> ().enabled = true;
			Destroy (this);
		}

		for(var i = objectForUnlock.Count - 1; i > -1; i--)
		{
			if (objectForUnlock[i] == null)
				objectForUnlock.RemoveAt(i);
		}



		if ( PlayerObjectInteract.isObjectInPlayerInteractiveZone( gameObject.GetComponent<Collider>() ) ){ objectInView = true; } else { objectInView = false; }
		if( playerInZone && Input.GetButton("Interact") && objectInView && timeTextVisible < 0){
			// Remplace temporairement le message par le warning
			tmpString = GameObject.Find ("lockedText").GetComponent<Text> ().text;
			GameObject.Find ("lockedText").GetComponent<Text> ().text = messageToDisplay;

			// Affiche le message
			GameObject.Find ("lockedText").GetComponent<Text> ().enabled = true;

			//Timer
			textVisible = true;
			timeTextVisible = timeLockedText;
		}

		//	Timer
		if (textVisible) {
			if (timeTextVisible < 0) {
				GameObject.Find ("lockedText").GetComponent<Text> ().enabled = false;
				GameObject.Find ("lockedText").GetComponent<Text> ().text = tmpString;

				textVisible = false;
			} else {
				timeTextVisible -= Time.deltaTime;
				print (timeTextVisible);
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
