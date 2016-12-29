using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	bool modeAttack = false;
	float attackSpeed = 1f;

	Transform player;
	NavMeshAgent nav;

	private float canAttack;
	private bool playerInZone = false;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();

		canAttack = attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (modeAttack) {

			canAttack -= Time.deltaTime;

			//Follow player
			nav.SetDestination (player.position);

			//Attack
			if (playerInZone && canAttack < 0) {
				canAttack = attackSpeed;
				print ("Paf, dans ta face!");
			}
		}

	}

	public void modeAttackOn(){
		modeAttack = true;
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
