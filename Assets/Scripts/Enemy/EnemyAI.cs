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
		// Place des GO/Compo dans des variables
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();

		canAttack = attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (modeAttack) {	// Si l'ennemie attaque le player

			canAttack -= Time.deltaTime;	// Decremente le timer

			//Follow player
			nav.SetDestination (player.position);
			nav.speed = speed;

			//Attack
			if (playerInZone && canAttack < 0) {
				canAttack = attackSpeed;
				PlayerHealth.takeDmg (degat);	// le player subit des degats via la fonction "takeDmg" du script "PlayerHealth"
			}
		}

		if (ammoInZone) {	// Si une munition touche l'ennemie
			ammoInZone = false;	// Desactive la variable
			// L'ennemie subit des degats via la fonction "takeDmg" du script "EnemyHealth" attache au GO
			gameObject.GetComponent<EnemyHealth> ().takeDmg ();	
		}	

	}

	// Fonction publique pour "activer" l'ennemie
	public void modeAttackOn(){
		modeAttack = true;
	}

	//Activate the Main function when player is near the door
	void OnTriggerEnter (Collider other){

		switch (other.gameObject.tag) {
			case "Player" :	// Si c'est le player
				playerInZone = true;
			break;
			case "Ammo":	// Si c'est un projectile lancé par le player
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
