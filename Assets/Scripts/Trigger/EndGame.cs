using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

	private GameObject player;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == player)
		{
			SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex)+1); // utiliser le nom de la scéne de fin de jeu en mode victoire.
		}

	}
}
