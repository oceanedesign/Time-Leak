using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	
	public GameObject[] enemyList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Trigger activation
	void OnTriggerEnter (Collider other){
		if (other.gameObject.tag == "Player") {	// Si le joueur passe dans le Collider
			
			foreach (GameObject enemy in enemyList){	// Pour chaque ennemie dans la liste
				enemy.GetComponent<EnemyAI>().modeAttackOn();	// Active l'ennemie
				PlayerHealth.stressMode = true;	// Active la barre de stress (redondant si deja active)
			}

			//Destroy enemy manager (GO)
			Destroy (gameObject);
		}
	}
}
