using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCommand : MonoBehaviour {

	static GameObject torche;

	public static bool hasFlashlight;
	float canEnableFlashlight, AntiSpam = 0.25f;

	// Use this for initialization
	void Start () {
		torche = gameObject.transform.GetChild(0).GetChild(1).gameObject;	// Recuperation de la lumiere de la torche sur le player

		// La torche n'est activable en debut de niveau que si l'on n'est pas dans le niveau 1
		if (SceneManager.GetActiveScene().name == "niveau1")	
			hasFlashlight = false;
		else
			hasFlashlight = true;
		
		torche.SetActive (false);	// Desactive la torche (sécurité)
	}
	
	// Update is called once per frame
	void Update () {
		canEnableFlashlight -= Time.deltaTime;	// Timer pour l'usage de la torche

		//Flashlight
		if ( Input.GetButton ("Flashlight") && canEnableFlashlight < 0 && hasFlashlight) {
			canEnableFlashlight = AntiSpam;	// Remet une valeur tampon pour limiter le spam

			if (torche.activeSelf)	// Active/Desactive la torche
				torche.SetActive (false);
			else
				torche.SetActive (true);
		}

	}

	// Fonction public pour le niveau 1
	public static bool torchIsActive(){
		return torche.activeSelf;
	}
}
