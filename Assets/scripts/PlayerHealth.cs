using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 0;
	public float currentHealth;
	public Slider healthSlider;
	public float stressAmount = 10;


	void Awake () {
		// Met le nom de la var public dans une var privée
		currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
		// Remplie la barre de stress
		currentHealth += stressAmount*Time.deltaTime;
		healthSlider.value = currentHealth;
	}
}