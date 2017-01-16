using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
	public float restartDelay = 5f;         // Time to wait before restarting the level
	public GameObject gameOverScreen;
	public AudioSource source;

	Animator anim;                          // Reference to the animator component.

	void Awake ()
	{
		// Set up the reference.
		gameOverScreen.SetActive(false);
	}


	void Update ()
	{
		// If the player has run out of health...
		if(PlayerHealth.player_isDead){
			source.mute = true;
			//Display GO Screen
			gameOverScreen.SetActive(true);

			// Libere le curseur
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
		}
	}
}