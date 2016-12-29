using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using GoogleMobileAds.Api;

public class GameController : MonoBehaviour {

	//private static GameController instance;

	public AdsController adsController;

	public CameraMovement cameraMovement;

	public GameObject restartButton;
	public GameObject pauseButton;
	public GameObject score;
	public GameObject scoreLabel;

	public GameObject pausePanel;
	public GameObject gameOverPanel;

	//private BannerView bannerView;

	void Awake(){

	
		adsController = GameObject.FindObjectOfType(typeof(AdsController)) as AdsController;
		adsController.hideBanner ();
		Time.timeScale = 1;
		//adsController.showBanner ();
		/*
		if (instance==null) {
			DontDestroyOnLoad(gameObject);
			instance = this;
		} else {
			Destroy (gameObject);
		}
		*/

	}

	

		
	void Start () {
		Debug.Log ("start"+adsController);

		if (pausePanel != null) {
			pausePanel.SetActive (false);
		}

		if (gameOverPanel != null) {
			gameOverPanel.SetActive (false);
		}
	}

	public void pauseTheGame(){

		adsController.showBanner ();
		
		if (pausePanel != null) {
			pausePanel.SetActive (true);
		}
		Time.timeScale = 0;

		hideGameButtonsAndScore ();
	}

	public void resumeTheGame(){

		adsController.hideBanner ();
		
		if (pausePanel != null) {
			pausePanel.SetActive (false);
		}
		Time.timeScale = 1;

		showGameButtonsAndScore ();
	}

	public void gameOver(){

		adsController.showBanner ();

		if (gameOverPanel != null) {
			gameOverPanel.SetActive (true);
		}

		Time.timeScale = 0;

		hideGameButtonsAndScore ();
	}



	public void reload(){
		//MainController.SwitchScene ("game");
		//SceneManager.LoadScene ("game");
		//Debug.Log ("play the game");
		//resumeTheGame ();

		adsController.hideBanner ();
		MainController.SwitchScene ("game");

		//pausePanel.SetActive (false);
	}

	public void backToLobby(){
		adsController.showBanner ();
		MainController.SwitchScene ("lobby");

	}
		
	public void stopCameraFollow(){
		cameraMovement.follow = false;
	}
		
	private void hideGameButtonsAndScore(){

		if (restartButton != null) {
			restartButton.SetActive (false);
		}
		if (pauseButton != null) {
			pauseButton.SetActive (false);
		}
		if (score != null) {
			score.SetActive (false);
		}
		if (scoreLabel != null) {
			scoreLabel.SetActive (false);
		}
	}

	private void showGameButtonsAndScore(){

		if (restartButton != null) {
			restartButton.SetActive (true);
		}
		if (pauseButton != null) {
			pauseButton.SetActive (true);
		}
		if (score != null) {
			score.SetActive (true);
		}
		if (scoreLabel != null) {
			scoreLabel.SetActive (true);
		}
	}
}
