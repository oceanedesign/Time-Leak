using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneGameOver : MonoBehaviour {

	public void LoadSceneG(){
		SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex));
	} 

}
