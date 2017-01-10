using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public Slider healthbar;
	Animator anim;

	void OnTriggerEnter(Collider other){
		Debug.Log ("Ca fait mal!");
		healthbar.value -= 20;
		if (healthbar.value <= 0) {
			anim.SetBool ("isDead", true);
		}
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
