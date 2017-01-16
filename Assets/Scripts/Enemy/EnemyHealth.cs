using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public enum levelEnemy{ level1, level2}
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
				health = 1; //vie du niveau 1
				break;

			case levelEnemy.level2 :
				health = 3; //vie du niveau2
				break;
		}
		halo = (Behaviour)GetComponent ("Halo");
	}
	
	// Update is called once per frame
	void Update () {

		// Die
		if (health <= 0) //si la vie de l'ennemi est inferieure ou egale a 0
			Destroy (gameObject); //alors l'ennemi est detruit

		if(dmgHaloTime < 0) // au bout de 0.1s l'halo montrant les dommages que subit l'ennemi se desactive
			halo.enabled = false;

		dmgHaloTime -= Time.deltaTime; 
		if (animTakeDmg) { 
			halo.enabled = true; //si l'ennemi prend des dommages, un halo s'active
			animTakeDmg = false;
			dmgHaloTime = dmgHaloTimeConst;
		}
		
	}

	public void takeDmg(){
		health --;
		animTakeDmg = true;

	}
}
