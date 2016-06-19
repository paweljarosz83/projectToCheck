using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
	public Text gameOverScoreText;
	public Text gameOverHighScoreText;


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
		highScoreText.enabled = false;
		scoreText.enabled = false;
	}
	public void enableScoreText(){
		highScoreText.enabled = true;
		scoreText.enabled = true;
	}
	

	void Update () {

		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount; 
			PlayerPrefs.SetInt("highscore", scoreCount);
		}

		scoreText.text = "Score: " + scoreCount;
		highScoreText.text = "High Score: " + highScoreCount;
		gameOverScoreText.text = "Score: " + scoreCount;
		gameOverHighScoreText.text = "High Score: " + highScoreCount;
	}
}
