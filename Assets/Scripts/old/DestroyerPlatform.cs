using UnityEngine;
using System.Collections;

public class DestroyerPlatform : MonoBehaviour {

	//public SpawnManager spawnManager;
	public SpawnManagerPoolingDlaWyzszych spawnManager;

	void OnTriggerEnter2D(Collider2D other){

            other.gameObject.SetActive(false);
            //other.gameObject.GetComponent<SpriteRenderer>().color = Color.gray;
            other.gameObject.GetComponent<Platforma>().wasHit = true;

           
            spawnManager.aktualnaLiczbaPlatform--;
        }
	}

