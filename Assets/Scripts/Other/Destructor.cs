using UnityEngine;
using System.Collections;

/**
 *
 *	Script pour détruire un objet au bout de timeToLive temps
 *	(fonction appliquee sur les prefab des munitions tirees)
 *
 **/

public class Destructor : MonoBehaviour {

	public int timeToLive = 2;

	// Use this for initialization
	void Start() {
		Destroy(gameObject, timeToLive);
	}

}
