using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossHealth : MonoBehaviour {

	public Slider healthbar;
	public int nbrToucheAvantMort = 5;
	Animator anim;

	float deathAnim = 0f;

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag != "Ammo") //si l'objet qui entre en collision avec le boss n'a pas pour tag "Ammo" alors celui-ci ne subit aucun degat
			return;
		
		healthbar.value -= 10; // (float)healthbar.maxValue / nbrToucheAvantMort; 
		// le boss perd 10 points de vie à chaque fois qu'il se fait toucher
	}

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); //la variable anim est un composant de l'animator du boss
	}
	
	// Update is called once per frame
	void Update () {

		if (healthbar.value <= 0) { //si la vie du boss est inferieur ou egale a 0 
			anim.SetBool ("isDead", true); //alors l'animation de mort s'active

			deathAnim += Time.deltaTime; 
			if (deathAnim > 3.5) { //lorsque l'animation de mort est terminee
				UnityEngine.SceneManagement.SceneManager.LoadScene ((UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex)+1); //passage a la scene suivante
			}
		}

	}
}
