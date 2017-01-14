using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MessageGame : MonoBehaviour {

	private GameObject player;
	public Text loadingText;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");	
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject == player)
		{
			loadingText.text = "Il y a un mot sur le lit d'Emma... ";
		}
	}
}
