using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinPool : MonoBehaviour {

	public GameObject coinA;
	public GameObject coinB;
	public List<GameObject> pulaObiektow;

	void Start () {
		pulaObiektow = new List<GameObject> ();

		for (int i=0; i<6; i++) {

			int los = Random.Range (0, 2);
			if (los == 0) {

				GameObject obj = (GameObject)Instantiate(coinA);
				obj.SetActive(false);
				pulaObiektow.Add (obj);

			}

			if (los == 1) {

				GameObject obj = (GameObject)Instantiate(coinB);
				obj.SetActive(false);
				pulaObiektow.Add (obj);

			}
		}
	}

	public GameObject getObiektZPuli(){

		foreach(GameObject platforma in pulaObiektow){
			if(!platforma.activeInHierarchy){
				return platforma;
			}
		}
		return zrobRandomowaPlatforme ();
	}

	private GameObject zrobRandomowaPlatforme(){
		int los = Random.Range (0, 1);
		if (los == 0) {
			GameObject obj = (GameObject)Instantiate(coinA);
			obj.SetActive(false);
			pulaObiektow.Add (obj);
			return obj;
		}

		if (los == 1) {
			GameObject obj = (GameObject)Instantiate(coinB);
			obj.SetActive(false);
			pulaObiektow.Add (obj);
			return obj;
		}

		return null;
	}
}
