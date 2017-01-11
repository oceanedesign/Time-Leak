using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCommand : MonoBehaviour {

	static GameObject torche;

	public static bool hasFlashlight;
	float canEnableFlashlight, AntiSpam = 0.25f;

	// Use this for initialization
	void Start () {
	//	torche = this.gameObject.transform.Find ("flashLight").gameObject;
		torche = gameObject.transform.GetChild(0).GetChild(1).gameObject;
		if (SceneManager.GetActiveScene().name == "niveau1")
			hasFlashlight = false;
		else
			hasFlashlight = true;
		torche.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		canEnableFlashlight -= Time.deltaTime;

		//Flashlight
		if ( Input.GetButton ("Flashlight") && canEnableFlashlight < 0 && hasFlashlight) {
			canEnableFlashlight = AntiSpam;

			if (torche.activeSelf)
				torche.SetActive (false);
			else
				torche.SetActive (true);
		}

	}

	public static bool torchIsActive(){
		return torche.activeSelf;
	}
}
