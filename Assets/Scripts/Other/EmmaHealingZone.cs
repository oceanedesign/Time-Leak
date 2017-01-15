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
	
		if (playerInZone) {
			if (deltaTimeHeal < 0) {
				PlayerHealth.takeHeal (1);
				deltaTimeHeal = deltaTimeHealConst;
			}
		}

		deltaTimeHeal -= Time.deltaTime;
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
