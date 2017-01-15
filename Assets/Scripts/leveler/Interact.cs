using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interact : MonoBehaviour {

	//Public
	public enum objectT{ door, ammo, clue, nounours, flashlight, other }
	public objectT TypeDeLObjet;
	public float AntiSpam = 0.5f;
	public bool doorOpen, displayGUI = false;

	//Clue
	public RawImage clue_imageDansHUD;

	private float canInteract;
	private bool playerInZone, inPlayerZone, objectInView = false;
	private int smooth = 2;
	private int DoorOpenAngle = 90;
	private Vector3 defaultRot;
	private Vector3 openRot;

	// Use this for initialization
	void Start () {
		canInteract = AntiSpam;
		defaultRot = transform.eulerAngles;
		openRot = new Vector3 (defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);
		if (clue_imageDansHUD) {
			clue_imageDansHUD.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {

		if ( PlayerObjectInteract.isObjectInPlayerInteractiveZone( gameObject.GetComponent<Collider>() ) ){
			objectInView = true;
		} else {
			objectInView = false;
		}

		canInteract -= Time.deltaTime;

		switch (TypeDeLObjet) {
			case objectT.door:
				if (!doorOpen) {	//	Close door
					transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
				} else {	// Open door
					transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
				}

				if( playerInZone && Input.GetButton("Interact") && canInteract < 0 && objectInView){
					canInteract = AntiSpam;
					doorOpen = !doorOpen;
				}
			break;

			case objectT.ammo:
				if (playerInZone && AmmoManager.hasBackpack) {
					AmmoManager.addAmmo (1);
					gameObject.SetActive (false);	
				}
			break;

			case objectT.nounours:
				if (playerInZone && Input.GetButton ("Interact") && objectInView) {
					AmmoManager.hasBackpack = true;
					Destroy(gameObject);
				}
				break;

			case objectT.flashlight:
				if (playerInZone && Input.GetButton ("Interact") && objectInView) {
					PlayerCommand.hasFlashlight = true;
					Destroy(gameObject);
				}
				break;

			case objectT.clue:
			
				if (playerInZone && Input.GetButton("Interact") && objectInView){
					clue_imageDansHUD.enabled = true;
					Destroy(gameObject);

					PlayerHealth.takeHeal();
				}	

			break;

			case objectT.other:
				print ("Arthur, t'as pas pensé à tout!");
			break;

			default:
				print ("[Error] Switch mal utilisé");
			break;
		}

	}

/*
	void OnGUI(){
		if (displayGUI) {
			if (playerInZone) {
				GameObject.GetComponent<Text> ("interactText").enabled = true;
			} else {
				GameObject.GetComponent<Text> ("interactText").enabled = false;
			}
		}
	}
*/

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