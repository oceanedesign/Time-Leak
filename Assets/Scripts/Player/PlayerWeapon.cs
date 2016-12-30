using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public GameObject[] ammoPrefab;
	public float thrust = 10f;

	int listAmmoSize;

	// Use this for initialization
	void Start () {
		listAmmoSize = ammoPrefab.Length;
	}
	
	// Update is called once per frame
	void Update () {

		//Lancer de bordel
		if( Input.GetButtonDown("Fire1") && AmmoManager.ammo > 0){
			GameObject lego = (GameObject)Instantiate(ammoPrefab[ Random.Range(0, listAmmoSize) ], new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			lego.GetComponent<Rigidbody> ().AddForce (-transform.forward * thrust, ForceMode.Impulse);

			AmmoManager.shot ();
		}

	}
}
