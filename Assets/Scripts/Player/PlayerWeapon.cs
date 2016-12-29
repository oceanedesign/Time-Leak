using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public GameObject ammoPrefab;
	public float thrust = 10f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Lancer de bordel
		if(Input.GetButtonDown("Fire1")){
			GameObject lego = (GameObject)Instantiate(ammoPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			lego.GetComponent<Rigidbody> ().AddForce (-transform.forward * thrust, ForceMode.Impulse);//(transform.forward * thrust);
		}

	}
}
