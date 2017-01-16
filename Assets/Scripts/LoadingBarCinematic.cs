using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBarCinematic : MonoBehaviour {


	AsyncOperation ao;
	public Slider progBar;
	public Text loadingText;


	// Use this for initialization
	void Start () {
		loadingText.text = "Chargement ..."; 
		StartCoroutine (LoadLevelWithRealProgress());	
	}
		

	IEnumerator LoadLevelWithRealProgress()
	// fonction montrant le chargement du niveau suivant 
	{
		yield return new WaitForSeconds (1);
		ao = SceneManager.LoadSceneAsync ((SceneManager.GetActiveScene().buildIndex)+1); //chargement de la scene suivante de maniere asychrone
		ao.allowSceneActivation = false; //la scene n'est pas active

		while (!ao.isDone) { //tant que le chargement n'est pas fini
			progBar.value = ao.progress; //la barre de chargement progresse en temps reel
			if (ao.progress == 0.9f) { //lorsque le niveau suivant est pret
				loadingText.text = "Appuyer sur 'T' pour continuer ...";  //le texte change pour que l'utilisateur agisse
				if (Input.GetKeyDown (KeyCode.T)) { //si le joueur appuie sur la touche T
					ao.allowSceneActivation = true; // passage a la scene suivante
				}
			}
			Debug.Log (ao.progress); //permet de voir la progression du chargement dans la console
			yield return null;
		}
	}
}
