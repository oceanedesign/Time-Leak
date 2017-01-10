using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// For disabled controller script
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 0;
	public Slider healthSlider;
	public Image fillBar;
	public float stressAmount = 1f;
	public Color beginningColor;
	public Color gameOverColor;

	public static float currentHealth;
	public static bool player_damaged, player_isDead = false;
	public static bool stressMode;

	float flashSpeed = 5f;
	Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	Image damageImage;

	void Awake () {
		// Met le nom de la var public dans une var privée
		currentHealth = startingHealth;
		stressAmount = stressAmount / 100;

		damageImage = GameObject.Find ("damageImage").GetComponent<Image> ();
		player_isDead = false;

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "niveau1")
			stressMode = false;
		else
			stressMode = true;

		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "niveau3")
			stressMode = false;
		else
			stressMode = true;
	}

	// Update is called once per frame
	void Update () {
		if (stressMode) {
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
		}

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
