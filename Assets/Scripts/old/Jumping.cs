using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Jumping : MonoBehaviour {





	public Text log;

	public AudioSource jumpSound;

	public Player player;
	private int up = 400;
	private int side = 400;
	private int maxPower = 900;
	private bool zwiekszajForce = false; 
	public Scale scale;


	float ys = 100f;
	float xs = 100f;
	float ye = 100f;
	float xe = 100f;
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



				jump2 (upForce,sideForce);
				string ta = "xs: "+xs+"ys:"+ys+"xe: "+xe+"ye: "+ye+"upForce: "+upForce+"sideForce: "+sideForce;
				log.text = ta;
			}
		}


	    if(Input.GetKeyDown("space")){
			zwiekszajForce = true;
		}
		if(Input.GetKeyUp("space")){
			zwiekszajForce = false;
		}
	}





	public void jump2(int upForce,int sideForce){
		if (player.ableToJump) {
			jumpSound.Play ();
			if (sideForce > 900) {
				sideForce = 900;
			}
			if (upForce > 900) {
				upForce = 900;
			}
			if (sideForce > 0) {

				player.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (sideForce,upForce*1.3f));
				player.ableToJump = false;
			}
		}
		up = 0;
		side = 0;
		//Application.OpenURL("market://details?id=YOUR_ID");
	}
}
