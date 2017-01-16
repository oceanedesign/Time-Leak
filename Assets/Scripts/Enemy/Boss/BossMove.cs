using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossMove : MonoBehaviour {

	public Transform player;
	static Animator anim; 
	public Slider healthbar;

	float animationTime = 0f;
	Vector3 dmgPositionFlamethrower = new Vector3(0, 100, 0);

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		//Desactive le lance flamme
		gameObject.transform.FindChild ("Flamethrower").FindChild("FlamethrowerParticle").gameObject.SetActive (false);
		gameObject.transform.FindChild ("Flamethrower").FindChild ("FlamethrowerBox").transform.position = dmgPositionFlamethrower;
	}
	
	// Update is called once per frame
	void Update () {

		if (healthbar.value <= 0) //si la vie du boss est inferieure ou egal a 0
			return; //alors il ne pourra ni attaquer, ni attendre (animation de mort a l'aide du script BossHealth.cs

		if (anim.GetBool ("isAttacking")) { //si le boss attaque
			animationTime += Time.deltaTime;
			if (animationTime >= 3.367) {
				//Reset
				animationTime = 0; //celle si doit se faire en entiere avant de passer à l'animation suivante
				//Animation Controller
				anim.SetBool ("isIdle", true); 
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isAttacking", false);
				//Disable Flamethrower
				gameObject.transform.FindChild ("Flamethrower").FindChild("FlamethrowerParticle").gameObject.SetActive (false);
				gameObject.transform.FindChild ("Flamethrower").FindChild ("FlamethrowerBox").transform.position = dmgPositionFlamethrower;
				return;
			}
			if (animationTime > 2) {
				//Enable Flamethrower Collider
				gameObject.transform.FindChild ("Flamethrower").FindChild ("FlamethrowerBox").transform.position = gameObject.transform.FindChild ("Flamethrower").transform.position;
			}
			//Enable Flamethrower Animation
			gameObject.transform.FindChild ("Flamethrower").FindChild("FlamethrowerParticle").gameObject.SetActive (true);
			return;
		}
		
		Vector3 direction = player.position - this.transform.position;
		//float angle = Vector3.Angle (direction, this.transform.forward);
		if (Vector3.Distance (player.position, this.transform.position) < 20 && (anim.GetBool("isIdle") || anim.GetBool("isWalking")) ) {
			// si la distance entre le joueur et le boss est inferieure à 20 et si le boss a pour animation l'attente ou la marche
			direction.y = 0; //la direction suivant l'axe y du joueur est impossible

			transform.LookAt(player);	//le boss regarde le joueur

			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 8) {
				this.transform.Translate (0, 0, 0.5f); //s'approche du joueur a une vitesse de 0.5
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			} else {
				anim.SetBool ("isAttacking", true); //si la distance entre le joueur et le boss est inferieur a 8 alors l'ennemi attaque 
				anim.SetBool ("isWalking", false);				
			}
		
		} 
		else 
		{
			anim.SetBool ("isIdle", true); //sinon l'ennemi attend
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);	
		}
	
	}
}
