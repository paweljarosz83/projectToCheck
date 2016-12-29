using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioController : MonoBehaviour{

	public AudioSource jumpSound1;


	/*
	private static AudioController instance;

	void Awake (){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}
		DontDestroyOnLoad (this);
	}
	*/

	public void playJumpingSound (int force){
		if (force <= 300) {
			jumpSound1.Play ();
		} else {
			jumpSound1.Play ();
		}
	}
	public static void disableSounds(){
		AudioListener.pause = true;
	}
	public static void enableSounds(){
		AudioListener.pause = false;
	}
}

