using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
	public float restartDelay = 5f;         // Time to wait before restarting the level
	public GameObject gameOverScreen;

	Animator anim;                          // Reference to the animator component.

	void Awake ()
	{
		// Set up the reference.
//		anim = GetComponent <Animator> ();
		gameOverScreen.SetActive(false);
	}


	void Update ()
	{
		// If the player has run out of health...
		if(PlayerHealth.player_isDead){

			//Display GO Screen
			gameOverScreen.SetActive(true);

			Cursor.lockState = CursorLockMode.Confined;
			Cursor.visible = true;
			// ... tell the animator the game is over.
	//		anim.SetTrigger ("GameOver");
		}
	}
}