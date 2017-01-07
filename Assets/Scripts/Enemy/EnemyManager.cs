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
			foreach (GameObject enemy in enemyList){
				enemy.GetComponent<EnemyAI>().modeAttackOn();
				PlayerHealth.stressMode = true;
			}
			//Destroy enemy manager
			Destroy (gameObject);
		}
	}
}
