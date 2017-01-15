using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

	public void LoadScene(){
		SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex)+1);
	} 

}
