using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	//public GameObject wskaznik;

	public GameController gameController;
	public ScoreManager scoreManager;

	private const string PLATFORMA = "platforma";

	private Rigidbody2D rb;
	bool doubleJump = false;
	public bool grounded = false;
	//public Transform groundCheck;
	public bool ableToJump  = true;
	private float granicaSmierciY = 0;



	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		//zamaist takiego znajdowania mozna poprostu dodac komponent w unity 
		//gameController = (GameController)GameObject.Find ("Canvas").GetComponent ("GameController");
	}

	void OnCollisionEnter2D(Collision2D c){
		
		//Instantiate(wskaznik, c.transform.position, Quaternion.identity);
		//c.gameObject.GetComponent<SpriteRenderer>().color = Color.green;

		//if platform wasn't hit before add point, <Platforma> is a script
		if (c.gameObject.GetComponent<Platforma> ().wasHit == false) {
			scoreManager.addPoint();
		}
		//set was hit to true so another hit with the same platform doesn't add point
		c.gameObject.GetComponent<Platforma> ().wasHit = true;

		//after collision with platform make able to jump
		if (c.gameObject.tag == PLATFORMA) {
			ableToJump = true;
		}

		//after collision slow the ball down to 5
		if (rb.velocity.x>5f){
			rb.velocity = new Vector2(5f,rb.velocity.y);
		}

		Vector2 v = new Vector2 (c.transform.position.x, c.transform.position.y);
		granicaSmierciY = c.transform.position.y-0.8f;
	}

	void OnCollisionExit2D(Collision2D c){
		Debug.Log ("exit");
		if (c.gameObject.tag == PLATFORMA) {
			ableToJump = false;
		}
	}

	void FixedUpdate(){

		//keep ball's speed at 5
		if (rb.velocity.x<5f){
			//rb.AddForce (new Vector2 (6,0));
		}

		if (rb.position.y <= granicaSmierciY) {
			//gameController.playFallingSound();
			//System.Threading.Thread.Sleep(1000);
			gameController.stopCameraFollow();
			//Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnBecameInvisible(){
		gameController.gameOver ();
		Time.timeScale = 0;
	}


	void Update(){
		//https://docs.unity3d.com/Manual/Layers.html
		int layerMask = 1 << LayerMask.NameToLayer("Player");
		layerMask = ~layerMask;

		Vector2 v = new Vector2 (transform.position.x-transform.localScale.x/2, transform.position.y-transform.localScale.y/2);
		RaycastHit2D hit = Physics2D.Raycast (v, Vector2.down,0.0000001f);
		//Debug.DrawRay (transform.position,Vector2.down,Color.green,1);

		float d = hit.distance;
		//Debug.Log ("dist "+d);
		if (hit.collider!=null && hit.distance<0.0000001f) {
			//if (hit.collider.tag == "platform") {
			ableToJump = true;

		} else {
			ableToJump = false;
		}
	}
}
