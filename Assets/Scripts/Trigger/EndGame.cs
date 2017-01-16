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
		if (col.gameObject == player && !gameObject.GetComponent<Locker> ()) //si le joueur se trouve dans la zone d'activation du trigger que tous les objets ont ete recupere
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true; //active le curseur

			SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex)+1); // passage a la scene suivante
		}

	}
}
