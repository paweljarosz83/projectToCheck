using UnityEngine;
using System.Collections;

public class Platforma : MonoBehaviour {

	public bool wasHit = false;
	
	void OnCollision2D(Collider2D c){
		
		if (gameObject.GetComponent<EdgeCollider2D> ()) {
			Debug.Log ("a");
		}
		if (gameObject.GetComponent<BoxCollider2D> ()) {
			Debug.Log ("b");
		}

		wasHit = true;
	
	}
}
