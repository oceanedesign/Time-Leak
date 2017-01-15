using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class MessageGame : MonoBehaviour { 

	public string message; 
	public bool messageOnInteract = false;
	Interact interactInstance;

	// Use this for initialization 
	void Start () { 
		if (messageOnInteract) {
			interactInstance = GetComponent<Interact> ();
		}
	} 

	void Update(){
		if (messageOnInteract) {
			if ( interactInstance.isInteract() ) {
				GameObject.Find ("lockedText").GetComponent<Text> ().text = message; 
				Destroy (this);
			}
		}
	}

	void OnDestroy(){ 
		GameObject.Find ("lockedText").GetComponent<Text> ().text = message; 
	} 
} 