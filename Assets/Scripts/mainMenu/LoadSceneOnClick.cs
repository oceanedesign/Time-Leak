using UnityEngine;
using System.Collections;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadScene(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	} 

}
