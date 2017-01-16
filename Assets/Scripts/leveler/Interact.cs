using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Interact : MonoBehaviour {

	//Public
	public enum objectT{ door, ammo, clue, nounours, flashlight }	// Liste de types d'objets
	public objectT TypeDeLObjet;	// Choix du type de l'objet

	// Variables pour parametrer le script sur GO
	public float AntiSpam = 0.5f;
	public bool doorOpen, displayGUI = false;
	bool isInteractObject = false;
	//Clue
	public RawImage clue_imageDansHUD;

	// Variables priveess
	private float canInteract;
	private bool playerInZone, inPlayerZone, objectInView = false;
	private int smooth = 2;
	private int DoorOpenAngle = 90;
	private Vector3 defaultRot;
	private Vector3 openRot;

	// Use this for initialization
	void Start () {
		// Traduction dans des variables privees
		canInteract = AntiSpam;
		defaultRot = transform.eulerAngles;
		openRot = new Vector3 (defaultRot.x, defaultRot.y + DoorOpenAngle, defaultRot.z);

		// Enleve l'image des indices du HUD au lancement de la scene
		if (clue_imageDansHUD) {
			clue_imageDansHUD.enabled = false;
		}
	}

	// Update is called once per frame
	void Update () {

		// Si l'objet est dans la zone d'interaction du joueur
		if ( PlayerObjectInteract.isObjectInPlayerInteractiveZone( gameObject.GetComponent<Collider>() ) ){
			objectInView = true;
		} else {
			objectInView = false;
		}

		// Anti spam (pour les portes)
		canInteract -= Time.deltaTime;

		switch (TypeDeLObjet) {	// Switch pour determiner comment le player interagie avec le GO

			//	Si le GO est une porte
			///////////////////////////////////////////
			case objectT.door:
				// Mouvement de la porte
				if (!doorOpen) {	//	Close door
					transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, defaultRot, Time.deltaTime * smooth);
				} else {	// Open door
					transform.eulerAngles = Vector3.Slerp(transform.eulerAngles, openRot, Time.deltaTime * smooth);
				}
				
				// Quand le jour interagie avec la porte
				if( playerInZone && Input.GetButton("Interact") && canInteract < 0 && objectInView){
					canInteract = AntiSpam;
					doorOpen = !doorOpen;
					isInteractObject = true;
				}
			break;

			//	Si le GO est une munition a ramasser
			///////////////////////////////////////////
			case objectT.ammo:
				// Quand le joueur marche sur le GO et qu'il a le sac
				if (playerInZone && AmmoManager.hasBackpack) {	
					AmmoManager.addAmmo (1);	// Rajoute une munition avec la fonction "addAmmo" du script "AmmoManager"
					Destroy(gameObject);	// Detruit le GO
				}
			break;

			//	Si le GO est le nounours (scene 1)
			///////////////////////////////////////////
			case objectT.nounours:
				if (playerInZone && Input.GetButton ("Interact") && objectInView) {
					AmmoManager.hasBackpack = true;	// Met la variable "hasBackpack" a vraie pour pouvoir ramasser des munitions
					Destroy(gameObject);	// Detruit le GO
				}
			break;

			//	Si le GO est la torche (scene 1)
			///////////////////////////////////////////
			case objectT.flashlight:
				if (playerInZone && Input.GetButton ("Interact") && objectInView) {
					PlayerCommand.hasFlashlight = true;	// Met la variable "hasFlashlight" a vraie pour pouvoir utiliser la torche
					Destroy(gameObject);	// Detruit le GO
				}
				break;

			//	Si le GO est un indice
			///////////////////////////////////////////
			case objectT.clue:
			
				if (playerInZone && Input.GetButton("Interact") && objectInView){
					clue_imageDansHUD.enabled = true;	// Affiche l'indice dans le HUD
					Destroy(gameObject);	// Detruit le GO
					
					// Redonne de la sante au player
					PlayerHealth.takeHeal(2);
				}	

			break;

			default:	// Error case
				print ("[Error] Switch mal utilisé");
			break;
		}

	}
		
	public bool isInteract(){
		return isInteractObject;
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