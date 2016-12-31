using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// For disabled controller script
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 0;
	public static float currentHealth;
	public Slider healthSlider;
	public Image fillBar;
	public float stressAmount = 1f;
	public Color beginningColor;
	public Color gameOverColor;

	public static bool player_damaged, player_isDead = false;
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
		if(player_damaged)
		{
			damageImage.color = flashColour;
		}
		else
		{
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		player_damaged = false;

		//Die
		if (healthSlider.value == healthSlider.maxValue && !player_isDead)
			Death ();
	}

	public static void takeDmg(int dmg){
		currentHealth += ((float)dmg / 10);
		player_damaged = true;
	}

	void Death ()
	{
		player_isDead = true;

		print ("You die");

//		playerAudio.clip = deathClip;
//		playerAudio.Play ();

		GetComponent<FirstPersonController>().enabled = false;
		//playerShooting.enabled = false;
	}

}
