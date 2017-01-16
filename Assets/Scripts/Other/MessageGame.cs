using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class MessageGame : MonoBehaviour { 

	public string message; 
	public bool messageOnInteract = false;
	public bool messageOnActive = false;
	Interact interactInstance;

	// Use this for initialization 
	void Start () { 
		// Condition pour eviter les messages d'erreurs
		if (messageOnInteract) {
			// Cree une instance du script Interact
			interactInstance = GetComponent<Interact> ();
		}
	} 

	void Update(){
		if (messageOnInteract) {
			if ( interactInstance.isInteract() ) {	// Si le player interagie avec le GO
				GameObject.Find ("lockedText").GetComponent<Text> ().text = message;	// Change le texte du HUD
				Destroy (this);	// Detruit le script
			}
		}

		if (messageOnActive) {
			if (gameObject.activeSelf) {	// Si le GO est actif dans le scene (utilisation de la lampe torche)
				GameObject.Find ("lockedText").GetComponent<Text> ().text = message;	// Change le texte du HUD
				Destroy (this);	// Detruit le script
			}
		}
	}

	// Change le texte du HUD quand le GO est détruit (recuperation d'indice)
	void OnDestroy(){ 
		GameObject.Find ("lockedText").GetComponent<Text> ().text = message; 
	} 
} 