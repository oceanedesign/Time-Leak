using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingBar : MonoBehaviour {

	AsyncOperation ao;
	public GameObject loadingBarMenu;
	public GameObject mainMenuPanel;
	public Slider progBar;
	public Text loadingText;

	public void LoadLevel(){
		loadingBarMenu.SetActive (true); //active le panel permettant d'afficher la barre de chargement 
		mainMenuPanel.SetActive (false); //desactive le menu d'entre-deux niveaux
		loadingText.text = "Chargement ...";
		StartCoroutine (LoadLevelWithRealProgress());
	}

	IEnumerator LoadLevelWithRealProgress()
	{
		yield return new WaitForSeconds (1);
		ao = SceneManager.LoadSceneAsync ((SceneManager.GetActiveScene().buildIndex)+1);//chargement de la scene suivante de maniere asychrone
		ao.allowSceneActivation = false;

		while (!ao.isDone) {//tant que le chargement n'est pas fini
			progBar.value = ao.progress;//la barre de chargement progresse en temps reel
			if (ao.progress == 0.9f) { //lorsque le niveau suivant est pret
				loadingText.text = "Appuyer sur 'T' pour continuer ...";//le texte change pour que l'utilisateur agisse
				if (Input.GetKeyDown (KeyCode.T)) {//si le joueur appuie sur la touche T
					ao.allowSceneActivation = true;// passage a la scene suivante
				}
			}
			Debug.Log (ao.progress);//permet de voir la progression du chargement dans la console
			yield return null;
		}
	}
		

}
