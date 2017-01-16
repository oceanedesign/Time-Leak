using UnityEngine;
using System.Collections;

public class QuitOnClick : MonoBehaviour {

	public void Quit(){
		// fonction permettant de quitter le jeu
		#if UNITY_EDITOR
				UnityEditor.EditorApplication.isPlaying = false;
		#else
				Application.Quit();
		#endif
	}
}
