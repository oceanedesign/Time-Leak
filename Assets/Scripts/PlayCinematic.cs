using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class PlayCinematic : MonoBehaviour {

	public MovieTexture movie;
	private AudioSource audio;

	// Use this for initialization
	void Start () {
		//fonction permettant de jouer la cinematique
		GetComponent<RawImage>().texture = movie as MovieTexture; //utilisation du video comme texture
		audio = GetComponent<AudioSource>(); //ajout d'une source audio
		audio.clip = movie.audioClip; //utilisation de la musique de la video comme son
		movie.Play(); //activation de la video
		audio.Play(); // activation du son de la video
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) && movie.isPlaying) //si la video est en cours et que l'utilisateur appuie sur la barre d'espace
		{
			movie.Pause (); //la video est en pause
		}
		else if (Input.GetKeyDown (KeyCode.Space) && !movie.isPlaying)  //si la video est en pause et que l'utilisateur appuie sur la barre d'espace
		{
			movie.Play (); //la video s'active
		}
	}
}
