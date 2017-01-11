using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	public bool modeAttack = false;
	public float attackSpeed = 1f;
	public float speed = 1f;
	public int degat = 1;

	Transform player;
	NavMeshAgent nav;

	private float canAttack;
	private bool playerInZone, ammoInZone = false;

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
			nav.speed = speed;

			//Attack
			if (playerInZone && canAttack < 0) {
				canAttack = attackSpeed;
				PlayerHealth.takeDmg (degat);
			}
		}

		if (ammoInZone) {
			ammoInZone = false;
			gameObject.GetComponent<EnemyHealth> ().takeDmg ();
		}

	}

	public void modeAttackOn(){
		modeAttack = true;
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){

		switch (other.gameObject.tag) {
			case "Player" :
				playerInZone = true;
			break;
			case "Ammo":
				ammoInZone = true;
				Destroy (other.gameObject);
			break;
		}
	}

	//Deactivate the Main function when player is go away from door
	void OnTriggerExit (Collider other){

		switch (other.gameObject.tag) {
			case "Player" :
				playerInZone = false;
				break;
			case "Ammo":
				ammoInZone = false;
				break;
		}
	}
}
