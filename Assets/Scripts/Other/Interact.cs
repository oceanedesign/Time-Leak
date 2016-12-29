using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interact : MonoBehaviour {

	//Public
	public enum objectT{ door, ammo, clue, other }
	public objectT TypeDeLObjet;
	public float AntiSpam = 0.5f;
	public bool doorOpen, displayGUI = false;

	//Clue
	public RawImage clue_imageDansHUD;

	//Dev life <3
	private float canInteract;
	//	Door
	private bool playerInZone = false;
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

		canInteract -= Time.deltaTime;

		switch (TypeDeLObjet) {
			case objectT.door:
				if (!doorOpen) {	//	Close door
					transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
				} else {	// Open door
					transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
				}

				if( playerInZone && Input.GetButton("Interact") && canInteract < 0 ){
					canInteract = AntiSpam;
					doorOpen = !doorOpen;
				}
			break;

			case objectT.ammo:
				if (playerInZone && Input.GetButton ("Interact")) {
					print ("Ce sont des munitions! Piou piou piou!!");
					gameObject.SetActive (false);
					/*	Munition
					GameObject.Find().GetComponent<Text>().get..	*/
				}
			break;
				
			case objectT.clue:
			
				if (playerInZone && Input.GetButton("Interact")){
					clue_imageDansHUD.enabled = true;
					gameObject.SetActive(false);
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

/*	// Too many conflict -> prefab => too many try
	void OnGUI(){
		if (displayGUI) {
			if (playerInZone) {
				GameObject.Find ("interactText").GetComponent<Text> ().enabled = true;
			} else {
				GameObject.Find ("interactText").GetComponent<Text> ().enabled = false;
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