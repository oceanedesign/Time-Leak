using UnityEngine;
using System.Collections;

public class BossFlamethrower : MonoBehaviour {

	public float attackSpeed = 1f;
	public int degat = 1;

	float canAttack;
	bool playerInZone = false;

	// Use this for initialization
	void Start () {
		canAttack = attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		canAttack -= Time.deltaTime;

		//Attack
		if (playerInZone && canAttack < 0) {
			canAttack = attackSpeed;
			PlayerHealth.takeDmg (degat);
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
