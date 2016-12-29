using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jumping : MonoBehaviour {

	public AudioController audioController;

	public Player player;

	private int up = 400;
	private int side = 400;
	private int maxForce = 800;

	private bool zwiekszajForce = false; 

	float ys = 100f;
	float xs = 100f;
	float ye = 100f;
	float xe = 100f;

	void Start(){
		audioController = GameObject.Find("AudioController").GetComponent<AudioController> ();
	}

	void Update(){

		if (Input.touches.Length > 0) {
			Touch t = Input.GetTouch (0);


			if (t.phase == TouchPhase.Began) {
				ys = t.position.y;
				xs = t.position.x;
			}

			if (t.phase == TouchPhase.Ended) {
				ye = t.position.y;
				xe = t.position.x;

				int upForce= (int)(ye - ys);
				int sideForce = (int)(xe - xs);



				jump (upForce,sideForce);
				//string ta = "xs: "+xs+"ys:"+ys+"xe: "+xe+"ye: "+ye+"upForce: "+upForce+"sideForce: "+sideForce;
				//log.text = ta;
			}
		}

		if (Input.GetKey ("down")) {
			jump (30,30);
		}
	}





	public void jump(int upForce,int sideForce){


		if (player.ableToJump) {

			int sumaryForce = sideForce + sideForce;
			//audioController.playJumpingSound (sumaryForce);


			
			if (sideForce > maxForce) {
				sideForce = maxForce;
			}
			if (upForce > maxForce) {
				upForce = maxForce;
			}
			if (sideForce > 0) {//skaczemy tylko do przodu
				//1,3 kompensuje granie w landscape i y nie mozna tak mocno naciagnac jak x
				player.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (sideForce/1.2f,upForce*1.3f));
				player.ableToJump = false;
			}
		}
		up = 0;
		side = 0;
	}
}
