using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	public AudioSource source;
	public AudioClip hover;


	public void Onhover () {
		source.PlayOneShot (hover);
	}
	

}
