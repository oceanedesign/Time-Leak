using UnityEngine;
using System.Collections;

public class Destructor : MonoBehaviour {

	public int timeToLive = 2;

	// Use this for initialization
	void Start() {
		Destroy(gameObject, timeToLive);
	}

}
