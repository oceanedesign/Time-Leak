using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;

public class PauseGame : MonoBehaviour {

	public Transform canvas;
	public Transform Player;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape) && !PlayerHealth.player_isDead) //si le joueur appuie sur la touche echap et qu'il n'est pas mort
		{
			Pause(); //appel la fonction Pause()
		}
	}

	public void Pause()
	//fonction permettant de mettre le jeu sur pause
	{
		if (canvas.gameObject.activeInHierarchy == false) 
		{
			canvas.gameObject.SetActive(true); // active CanvasPause
			Time.timeScale = 0; //arret du temps de jeu
			Player.GetComponent<FirstPersonController>().enabled = false; //le joueur ne bouge plus

			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true; //curseur visible
		} else {
			canvas.gameObject.SetActive(false); // desactive CanvasPause
			Time.timeScale = 1; //active le temps de jeu
			Player.GetComponent<FirstPersonController>().enabled = true; //acces au joueur

			Cursor.lockState = CursorLockMode.Locked;
			Cursor.visible = false; //curseur invisible
		}		
	}
}
