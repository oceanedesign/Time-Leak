using UnityEngine;
using System.Collections;

public class GlowOnFlashLight : MonoBehaviour {

	public bool enabledState = false;

	private Behaviour haloComponent;
	private bool nonDefaultAction = false;

	// Use this for initialization
	void Start () {
		haloComponent = (Behaviour)GetComponent ("Halo");	// Recuperation du composant "Halo" pour pouvoir le desactiver
		if (enabledState) {	// Active le Halo des le debut de la scene
			haloComponent.enabled = true;
			nonDefaultAction = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!nonDefaultAction) {	// Sauf si le GO doit avoir un effet independant
			if (PlayerCommand.torchIsActive ()) {	// Si la torche est active (allumee)
				haloComponent.enabled = true;
			} else {
				haloComponent.enabled = false;
			}
		}
	}
}
