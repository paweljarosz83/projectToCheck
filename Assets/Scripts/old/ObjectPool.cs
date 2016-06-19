using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool : MonoBehaviour {

	public GameObject platform300;
	public GameObject platform400;
	public List<GameObject> pulaObiektow;

	void Start () {
		pulaObiektow = new List<GameObject> ();

		for (int i=0; i<6; i++) {

			int los = Random.Range (0, 2);
			if (los == 0) {

				GameObject obj = (GameObject)Instantiate(platform300);
				obj.SetActive(false);
				pulaObiektow.Add (obj);

			}
			
			if (los == 1) {

				GameObject obj = (GameObject)Instantiate(platform400);
				obj.SetActive(false);
				pulaObiektow.Add (obj);

			}
		}
	}

	public GameObject getObiektZPuli(){

		foreach(GameObject platforma in pulaObiektow){
			if(!platforma.activeInHierarchy){
				float skala = Random.Range(0.8f,3f);
				platforma.transform.localScale = new Vector2 (skala,1);
				return platforma;
			}
		}
		return zrobRandomowaPlatforme ();
	}

	private GameObject zrobRandomowaPlatforme(){
		int los = Random.Range (0, 2);
		if (los == 0) {
			GameObject obj = (GameObject)Instantiate(platform300);
			obj.SetActive(false);
			pulaObiektow.Add (obj);
			return obj;
		}

		if (los == 1) {
			GameObject obj = (GameObject)Instantiate(platform400);
			obj.SetActive(false);
			pulaObiektow.Add (obj);
			return obj;
		}

		return null;
	}
}
