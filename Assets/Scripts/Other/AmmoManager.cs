using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AmmoManager : MonoBehaviour {

	public static int ammo;
	Text text;


	void Awake ()
	{
		text = GetComponent <Text> ();
		ammo = 5;
	}


	void Update ()
	{
		text.text = ""+ammo;
	}

	public static void addAmmo(int number){
		ammo += number;
	}

	public static void shot(){
		ammo--;
	}
}
