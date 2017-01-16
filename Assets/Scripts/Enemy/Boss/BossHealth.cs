using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public Slider healthbar;
	public int nbrToucheAvantMort = 5;
	Animator anim;

	float deathAnim = 0f;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag != "Ammo")
			return;
		
		healthbar.value -= 10; // (float)healthbar.maxValue / nbrToucheAvantMort; 
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (healthbar.value <= 0) {
			anim.SetBool ("isDead", true);

			deathAnim += Time.deltaTime;
			if (deathAnim > 3.5) {
				UnityEngine.SceneManagement.SceneManager.LoadScene ((UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex)+1);
			}
		}

	}
}
