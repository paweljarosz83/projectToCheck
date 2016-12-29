using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using GoogleMobileAds.Api;

public class MenuController : MonoBehaviour {

	private int soundOn = 1;
	private bool menuSceneLoaded = false;

	public GameObject settingsPanel;
	public GameObject helpPanel;

	public Button soundButton;
	public Sprite spriteON;
	public Sprite spriteOFF;

	public AdsController adsController;

	public void Awake (){
		settingsPanel.SetActive (false);
		helpPanel.SetActive (false);
		//turn sound on when game first starts
		//PlayerPrefs.GetInt ("soundOn", 1);
		adsController = GameObject.FindObjectOfType(typeof(AdsController)) as AdsController;
	}



	public void Start(){
		//spriteOFF = Resources.Load<Sprite> ("soundOFF");
		int soundSwith = Preferences.soundSwith;

		if (soundSwith == 1) {
			AudioController.enableSounds ();
			soundButton.image.sprite = spriteON;
		}
		if (soundSwith == 0) {
			AudioController.disableSounds ();
			soundButton.image.sprite = spriteOFF;
		}
		//soundToggleButton.GetComponent<Toggle> ().isOn = true;
	}

	public void toggleSounds(){
		soundButton.image.sprite = spriteOFF;

		int soundSwith = Preferences.soundSwith;

		if (soundSwith == 1) {
			soundButton.image.sprite = spriteOFF;

			Preferences.soundSwith = 0;
			AudioController.disableSounds ();
		}
		if (soundSwith == 0) {
			soundButton.image.sprite = spriteON;
	
			Preferences.soundSwith = 1;
			AudioController.enableSounds ();
		}
	}

	public void play(){
		adsController.hideBanner ();
		//adsController.destroyBanner();
		MainController.SwitchScene ("game");
	}

	public void rateTheGame(){
		Application.OpenURL ("market://details?id=com.slackballgame");
	}

	public void buyTheGame(){
		Application.OpenURL ("market://details?id=com.slackballgame");
	}

	public void showSettingsPanel(){
		if (settingsPanel != null) {
			settingsPanel.SetActive (true);
		}
	}

	public void hideSettingsPanel(){
		if (settingsPanel != null) {
			settingsPanel.SetActive (false);
		}
	}

	public void showHelpPanel(){
		if (helpPanel != null) {
			helpPanel.SetActive (true);
		}
	}

	public void hideHelpPanel(){
		if (helpPanel != null) {
			helpPanel.SetActive (false);
		}
	}
}
