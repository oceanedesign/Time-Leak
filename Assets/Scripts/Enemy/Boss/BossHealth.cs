using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public Slider healthbar;
	public int nbrToucheAvantMort = 5;
	Animator anim;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag != "Ammo")
			return;
		
		healthbar.value -= 10; // (float)healthbar.maxValue / nbrToucheAvantMort; 
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
