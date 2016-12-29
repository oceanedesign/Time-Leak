using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public GameObject ammoPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Lancer de bordel
		if(Input.GetButtonDown("Fire1")){
			var temp = (GameObject)Instantiate(ammoPrefab, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
			temp.GetComponent<Rigidbody>().AddForce(0, 0, 1f);
		}

	}
}
