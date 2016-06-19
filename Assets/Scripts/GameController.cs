using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject helpPanel;
	public GameObject settingsPanel;

	public GameObject pausePanel;
	public GameObject gameOverPanel;



	public void showHelpPanel(){
		helpPanel.SetActive (true);
	}

	public void hideHelpPanel(){
		helpPanel.SetActive (false);
	}


	public void showSettingsPanel(){
		
		settingsPanel.SetActive (true);
	}

	public void hideSettingsPanel(){

		settingsPanel.SetActive (false);
	}


	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}


		
	void Start () {

		if (helpPanel != null) {
			helpPanel.SetActive (false);
		}

		if (settingsPanel != null) {
			settingsPanel.SetActive (false);
		}
	
		if (pausePanel != null) {
			pausePanel.SetActive (false);
		}

		if (gameOverPanel != null) {
			gameOverPanel.SetActive (false);
		}
	}

	public void pauseTheGame(){
		pausePanel.SetActive (true);
	}

	public void resumeTheGame(){
		pausePanel.SetActive (false);
	}

	public void rateTheGame(){
		Application.OpenURL ("market://details?id=com.slackballgame");
	}

	public void buyTheGame(){
		Application.OpenURL ("market://details?id=com.slackballgame");
	}

	public void playTheGame(){
		Application.LoadLevel(1);
	}
	public void backToLobby(){
		Application.LoadLevel(0);
	}
}
