using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BossMove : MonoBehaviour {

	public Transform player;
	static Animator anim; 
	public Slider healthbar;

	double animationTime;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		animationTime = 3;
	}
	
	// Update is called once per frame
	void Update () {

		if (healthbar.value <= 0)
			return;

		if (anim.GetBool ("isAttacking")) {
			animationTime -= Time.deltaTime;
			if (animationTime < 0) {
				animationTime = 3;	
				anim.SetBool ("isIdle", true);
				anim.SetBool ("isWalking", false);
				anim.SetBool ("isAttacking", false);
			}
			return;
		}
		
		Vector3 direction = player.position - this.transform.position;
		//float angle = Vector3.Angle (direction, this.transform.forward);
		if (Vector3.Distance (player.position, this.transform.position) < 15 && (anim.GetBool("isIdle") || anim.GetBool("isWalking")) ) {

			direction.y = 0;

			transform.LookAt(player);	// Sauf si tu trouves trop brutal
//			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), Time.time * 0.1f );

			anim.SetBool ("isIdle", false);
			if (direction.magnitude > 8) {
				this.transform.Translate (0, 0, 0.2f);
				anim.SetBool ("isWalking", true);
				anim.SetBool ("isAttacking", false);
			} else {
				anim.SetBool ("isAttacking", true);
				anim.SetBool ("isWalking", false);				
			}
		
		} 
		else 
		{
			anim.SetBool ("isIdle", true);
			anim.SetBool ("isWalking", false);
			anim.SetBool ("isAttacking", false);	
		}
	
	}
}
