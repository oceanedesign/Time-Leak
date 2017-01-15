using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public enum levelEnemy{ level1, level2, level3, boss }
	public levelEnemy healthEnemy;

	int health;
	bool animTakeDmg = false;
	Behaviour halo;
	const float dmgHaloTimeConst = 0.1f;
	float dmgHaloTime;	

	// Use this for initialization
	void Start () {
		switch (healthEnemy) {
			case levelEnemy.level1 :
				health = 1;
				break;

			case levelEnemy.level2 :
				health = 3;
				break;

			case levelEnemy.boss :
				health = 5;
				break;
		}
		halo = (Behaviour)GetComponent ("Halo");
	}
	
	// Update is called once per frame
	void Update () {

		// Die
		if (health <= 0)
			Destroy (gameObject);

		if(dmgHaloTime < 0)
			halo.enabled = false;

		dmgHaloTime -= Time.deltaTime;
		if (animTakeDmg) {
			halo.enabled = true;
			animTakeDmg = false;
			dmgHaloTime = dmgHaloTimeConst;
		}
		
	}

	public void takeDmg(){
		health --;
		animTakeDmg = true;

	}
}
