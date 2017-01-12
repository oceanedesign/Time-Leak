using UnityEngine;
using System.Collections;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadScene(){

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
	} 

}
