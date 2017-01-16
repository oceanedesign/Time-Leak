using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// For disabled controller script
using UnityStandardAssets.Characters.FirstPerson;

public class PlayerHealth : MonoBehaviour {

	// Variable publiques (dans l'inspecteur)
	public int startingHealth = 0;
	public Slider healthSlider;
	public Image fillBar;
	public float stressAmount = 1f;
	public Color beginningColor;
	public Color gameOverColor;

	public static float currentHealth;
	public static bool player_damaged, player_heal, player_isDead = false;
	public static bool stressMode;

	// Varible privées
	float flashSpeed = 5f;
	Color flashColourDmg = new Color(1f, 0f, 0f, 0.1f);
	Color flashColourHeal = new Color(0f, 0f, 1f, 0.1f);
	Image damageImage;

	void Awake () {
		// Met le nom de la var public dans une var privée
		currentHealth = startingHealth;
		stressAmount = stressAmount / 100;	// Adapte la vitesse à la barre

		damageImage = GameObject.Find ("damageImage").GetComponent<Image> ();	// Stock l'Image dans la variable
		player_isDead = false;

		// N'active la progression du stress en début de niveau que au niveau 2
		if (UnityEngine.SceneManagement.SceneManager.GetActiveScene().name == "niveau2")
			stressMode = true;
		else
			stressMode = false;
	}

	// Update is called once per frame
	void Update () {
		//Debug	=>	La valeur minimal ne peut pas être inférieur à celle du slider
		if (currentHealth < healthSlider.minValue) {
			currentHealth = healthSlider.minValue;
		}

		if (stressMode) {
			// Remplie la barre de stress
			currentHealth += stressAmount*Time.deltaTime;
		}
		//Life update value
		healthSlider.value = currentHealth;
		fillBar.color = Color.Lerp (beginningColor, gameOverColor, healthSlider.value/ healthSlider.maxValue);	// Couleur de la barre de stress


		//HUD dmg/heal
		if(player_damaged)
		{
			damageImage.color = flashColourDmg;
		}
		else
		{
			if (player_heal) {
				damageImage.color = flashColourHeal;
			} else {
				damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
			}
		}
		player_damaged = player_heal = false;	// Desactive les deux booleans

		//Die
		if (healthSlider.value == healthSlider.maxValue && !player_isDead)
			Death ();
	}

	// Fonction statique publique pour faire subir des degats depuis d'autres scripts
	public static void takeDmg(int dmg){
		currentHealth += ((float)dmg / 10);
		player_damaged = true;
	}

	// Fonction statique publique pour faire soigner depuis d'autres scripts
	public static void takeHeal(int heal){
		currentHealth -= ((float)heal / 10);
		player_heal = true;
	}

	void Death ()
	{
		player_isDead = true;
		// Desactive les mouvements du joueur
		GetComponent<FirstPersonController>().enabled = false;
	}

}
