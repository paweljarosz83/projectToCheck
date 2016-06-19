using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scale : MonoBehaviour {
	
	int wysokosc = 0;
	
	public bool zwiekszaj = false;
	int i = 0;

	public RectTransform UIObject;
	
	void Start(){
		if (!UIObject){
			UIObject = (RectTransform)transform;
			
		}
	}
	
	void Update () {
		
		if (zwiekszaj) {
			Vector3 scale = UIObject.localScale;

			Vector3 newScale = new Vector3 (2, ++i, 0);
			transform.localScale = Vector3.Lerp (transform.localScale, newScale, 1 * Time.deltaTime);
			
			//SKALUJE, dziala ale probuje inaczej
			//UIObject.sizeDelta = new Vector2(2,10);
		} else {
			
			Vector3 newScale = new Vector3(2, 0, 0);
			transform.localScale = Vector3.Lerp (transform.localScale, newScale, 7 * Time.deltaTime);
		}
	}
}















