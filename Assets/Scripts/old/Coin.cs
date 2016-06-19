using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {



	void OnCollisionEnter2D (Collision2D c) {
		this.gameObject.SetActive (false);
	}
}
