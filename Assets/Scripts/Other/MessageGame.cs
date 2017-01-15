﻿using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class MessageGame : MonoBehaviour { 

	public string message; 

	// Use this for initialization 
	void Start () { 

	} 

	void OnDestroy(){ 
		GameObject.Find ("lockedText").GetComponent<Text> ().text = message; 
	} 
} 