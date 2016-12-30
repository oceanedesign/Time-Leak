using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 0;
	public static float currentHealth;
	public Slider healthSlider;
	public Image fillBar;
	public float stressAmount = 1f;
	public Color beginningColor;
	public Color gameOverColor;

	static bool damaged = false;
	float flashSpeed = 5f;
	Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	Image damageImage;

	void Awake () {
		// Met le nom de la var public dans une var privée
		currentHealth = startingHealth;
		stressAmount = stressAmount / 100;

		damageImage = GameObject.Find ("damageImage").GetComponent<Image> ();
	}

	// Update is called once per frame
	void Update () {
		// Remplie la barre de stress
		currentHealth += stressAmount*Time.deltaTime;
		healthSlider.value = currentHealth;
		fillBar.color = Color.Lerp (beginningColor, gameOverColor, healthSlider.value/ healthSlider.maxValue);
	
		//HUD dmg
		if(damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public static void takeDmg(int dmg){
		currentHealth += ((float)dmg / 10);
		damaged = true;
	}
}
