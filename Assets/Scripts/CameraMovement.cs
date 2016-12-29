
using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private Camera camera;
	public Transform player;

	public bool follow = true;

	void Awake(){
		camera = GetComponent<Camera>();
		follow = true;
	}
		
	void FixedUpdate(){
		if (follow == true && player!=null) {
			
			transform.position = Vector3.Lerp (transform.position, new Vector3 (player.transform.position.x,
				player.transform.position.y, -9f), Time.deltaTime * 3f);
		}
	}
}

