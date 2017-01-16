using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/**
 *
 *	Script pour recharger la scene courante
 *	(script utilise dans le menu apres un Game Over [Recommencer])
 *
 **/

public class LoadSceneGameOver : MonoBehaviour {

	public void LoadSceneG(){
		SceneManager.LoadScene ((SceneManager.GetActiveScene().buildIndex));
	} 

}
