using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class AmmoManager : MonoBehaviour {

	public static int ammo = 0;
	public static bool hasBackpack;
	Text text;


	void Awake ()
	{
		// Recupere le texte pour afficher le nombre de munition
		text = GetComponent <Text> ();
		// Le player ne peut recuperer de munition au debut du niveau 1
		if (SceneManager.GetActiveScene().name == "niveau1")
			hasBackpack = false;
		else
			hasBackpack = true;
	}

	// Met a jour le nombre de munition
	void Update ()
	{
		text.text = ""+ammo;
	}

	// Fonction statique publique pour rajouter des munitions
	public static void addAmmo(int number){
		ammo += number;
	}

	// Fonction statique publique pour utiliser une munition (tirer)
	public static void shot(){
		ammo--;
	}
}
