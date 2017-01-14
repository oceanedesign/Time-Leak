using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadScene(){

		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

		SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex)+1);
	} 

}
