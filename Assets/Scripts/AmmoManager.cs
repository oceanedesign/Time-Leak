using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoManager : MonoBehaviour {

	public static int ammo;
	Text text;


	void Awake ()
	{
		text = GetComponent <Text> ();
		ammo = 0;
	}


	void Update ()
	{
		text.text = ""+ammo;
	}
}
