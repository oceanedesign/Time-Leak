using UnityEngine;
using System.Collections;

public class EmmaHealingZone : MonoBehaviour {

	public float deltaTimeHealConst = 2f;

	bool playerInZone;
	float deltaTimeHeal;	

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		// Si le player est dans la zone d'influence (boxCollider Trigger)
		if (playerInZone) {
			if (deltaTimeHeal < 0) {	// Delais de temps entre chaque soin
				deltaTimeHeal = deltaTimeHealConst;	// Remet la valeur tampon
				PlayerHealth.takeHeal (1);	// Appel de la fonction "takeHeal" du script "PlayerHeath"
			}
		}

		deltaTimeHeal -= Time.deltaTime;	// Timer avant le prochain soin
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
