using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioController : MonoBehaviour {

	public int soundOn = 1;
	public GameObject soundToggleButton;


	void Start () {

		soundOn = PlayerPrefs.GetInt ("soundOn");

		if (soundOn == 1) {
			soundToggleButton.GetComponent<Toggle> ().isOn = true;
			AudioListener.pause = false;
		} else {
			soundToggleButton.GetComponent<Toggle> ().isOn = false;
			AudioListener.pause = true;
		}
	}

	public void toggleSound(){
			if (soundOn == 1) {
				soundOn=0;
				PlayerPrefs.SetInt ("soundOn",0);
				AudioListener.pause = true;
			}
			if (soundOn == 0) {
				soundOn = 1;
				PlayerPrefs.SetInt ("soundOn",1);
				AudioListener.pause = false;
			}
		}

	public void playJumpingSound(int force){

	}
}

