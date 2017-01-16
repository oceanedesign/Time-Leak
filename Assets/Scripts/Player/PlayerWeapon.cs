using UnityEngine;
using System.Collections;

public class PlayerWeapon : MonoBehaviour {

	public GameObject[] ammoPrefab;
	public float thrust = 10f;
	public GameObject canvasPause; 

	int listAmmoSize;

	// Use this for initialization
	void Start () {
		// Recupere le nombre de prefab pour l'optimisation de la boucle dans le Update
		listAmmoSize = ammoPrefab.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
		if( Input.GetButtonDown("Fire1") && AmmoManager.ammo > 0 && canvasPause.activeSelf==false){	// S'il y a des munitions et que le joueur tire
			GameObject lego = (GameObject)Instantiate(	// Instancie un objet a lancer
									ammoPrefab[ Random.Range(0, listAmmoSize) ], // Choisis un prefab aleatoirement parmis l'array de prefab
									new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation	// Place l'objet dans l'espace de la scene
							  );
			// Donne une impulsion au prefab a projeters
			lego.GetComponent<Rigidbody> ().AddForce (-transform.forward * thrust, ForceMode.Impulse);

			// Appel la fonction "shot" du script "AmmoManager"
			AmmoManager.shot ();
		}

	}
}
