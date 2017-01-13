using UnityEngine;
using System.Collections;

public class GlowOnFlashLight : MonoBehaviour {

	public bool enabledState = false;

	private Behaviour haloComponent;
	private bool nonDefaultAction = false;

	// Use this for initialization
	void Start () {
		haloComponent = (Behaviour)GetComponent ("Halo");
		if (enabledState) {
			haloComponent.enabled = true;
			nonDefaultAction = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!nonDefaultAction) {
			if (PlayerCommand.torchIsActive ()) {
				haloComponent.enabled = true;
			} else {
				haloComponent.enabled = false;
			}
		}
	}
}
