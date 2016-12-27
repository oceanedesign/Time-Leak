using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 0;
	public float currentHealth;
	public Slider healthSlider;
	public Image fillBar;
	public float stressAmount = 1f;
	public Color beginningColor;
	public Color gameOverColor;


	void Awake () {
		// Met le nom de la var public dans une var privée
		currentHealth = startingHealth;
		stressAmount = stressAmount / 100;
	}

	// Update is called once per frame
	void Update () {
		// Remplie la barre de stress
		currentHealth += stressAmount*Time.deltaTime;
		healthSlider.value = currentHealth;
		fillBar.color = Color.Lerp (beginningColor, gameOverColor, healthSlider.value/ healthSlider.maxValue);
	}
}
