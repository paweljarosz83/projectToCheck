using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreInGame;
	public Text scoreInGO;
	public Text highScoreInGO;

	public int scoreCount;
	public int highScoreCount;

	public float pointsPerSecond;
	public bool scoreIncreasing;

	void Start () {
		highScoreCount = PlayerPrefs.GetInt("highscore");
	}

	public void addPoint(){
		scoreCount++;
	}

	public void disableScoreText(){
		//highScoreText.enabled = false;
		//scoreInGame.enabled = false;
	}
	public void enableScoreText(){
		//highScoreText.enabled = true;
		//scoreInGame.enabled = true;
	}
	

	void Update () {

		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount; 
			PlayerPrefs.SetInt("highscore", scoreCount);
		}

		scoreInGame.text = "" + scoreCount;
		scoreInGO.text = "" + scoreCount;
		highScoreInGO.text = "" + highScoreCount;

		//highScoreText.text = "High Score: " + highScoreCount;
		//gameOverScoreText.text = "Score: " + scoreCount;
		//gameOverHighScoreText.text = "High Score: " + highScoreCount;
	}
}
