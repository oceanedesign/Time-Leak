using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	bool modeAttack = false;
	Transform player;
	NavMeshAgent nav;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		nav = GetComponent <NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (modeAttack) {
			nav.SetDestination (player.position);
		}

	}

	public void modeAttackOn(){
		modeAttack = true;
	}
}
