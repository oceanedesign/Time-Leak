using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public enum levelEnemy{ level1, level2, level3, boss }
	public levelEnemy healthEnemy;

	int health;

	// Use this for initialization
	void Start () {
		switch (healthEnemy) {
			case levelEnemy.level1 :
				health = 1;
				break;

			case levelEnemy.level2 :
				health = 2;
				break;

			case levelEnemy.level3 :
				health = 3;
				break;

			case levelEnemy.boss :
				health = 5;
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {

		// Die
		if (health <= 0)
			Destroy (gameObject);
		
	}

	public void takeDmg(){
		health -= 1;
	}
}
