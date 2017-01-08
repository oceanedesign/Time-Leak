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
	
	// Update is called once per frame
	void Update () {
	
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
