using UnityEngine;
using System.Collections;

public class PlayerCommand : MonoBehaviour {

	GameObject torche;

	float canEnableFlashlight, AntiSpam = 0.25f;

	// Use this for initialization
	void Start () {
	//	torche = this.gameObject.transform.Find ("flashLight").gameObject;
		torche = gameObject.transform.GetChild(0).GetChild(1).gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		canEnableFlashlight -= Time.deltaTime;

		//Flashlight
		if ( Input.GetButton ("Flashlight") && canEnableFlashlight < 0) {
			canEnableFlashlight = AntiSpam;

			if (torche.activeSelf)
				torche.SetActive (false);
			else
				torche.SetActive (true);
		}

	}
}
