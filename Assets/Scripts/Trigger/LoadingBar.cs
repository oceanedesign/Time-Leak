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
		loadingBarMenu.SetActive (true);
		mainMenuPanel.SetActive (false);
		loadingText.text = "Chargement ...";
		StartCoroutine (LoadLevelWithRealProgress());
	}

	IEnumerator LoadLevelWithRealProgress()
	{
		yield return new WaitForSeconds (1);
		ao = SceneManager.LoadSceneAsync ((SceneManager.GetActiveScene().buildIndex)+1);
		ao.allowSceneActivation = false;

		while (!ao.isDone) {
			progBar.value = ao.progress;
			if (ao.progress == 0.9f) {
				loadingText.text = "Appuyer sur 'T' pour continuer ...";
				if (Input.GetKeyDown (KeyCode.T)) {
					ao.allowSceneActivation = true;
				}
			}
			Debug.Log (ao.progress);
			yield return null;
		}
	}
		

}
