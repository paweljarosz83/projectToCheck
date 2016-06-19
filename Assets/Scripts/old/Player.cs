using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public GameObject wskaznik;

	GameController gameController;

	public ScoreManager scoreManager;
	private Rigidbody2D rb;
	bool doubleJump = false;
	public bool grounded = false;
	public Transform groundCheck;
	public bool ableToJump  = true;
	private float granicaSmierciY = 0;

	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		gameController = (GameController)GameObject.Find ("Canvas").GetComponent ("GameController");
	}

	void OnCollisionEnter2D(Collision2D c){
		ableToJump = true;
		//c.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

		if (c.gameObject.GetComponent<Platforma> ().wasHit == false) {
			scoreManager.addPoint();
		}
		c.gameObject.GetComponent<Platforma> ().wasHit = true;

		Vector2 v = new Vector2 (c.transform.position.x, c.transform.position.y);
		Instantiate(wskaznik, c.transform.position, Quaternion.identity);

		granicaSmierciY = c.transform.position.y-0.8f;
	}

	void FixedUpdate(){

		if (rb.position.y <= granicaSmierciY) {
			//gameController.playFallingSound();
			//System.Threading.Thread.Sleep(1000);

			gameController.stopCameraFollow();
			//Application.LoadLevel(Application.loadedLevel);
		}


		if (rb.velocity.x<5f){
			rb.AddForce (new Vector2 (6,0));
		}
	}

	void OnBecameInvisible(){
		gameController.gameOver ();
		Time.timeScale = 0;
	}
}
