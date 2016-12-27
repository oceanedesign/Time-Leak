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
		if (other.gameObject.tag == "Player") {
			/*
			for(enemy in enemyList){

				enemy.attack = true;

			}
			*/
		}
	}
}
