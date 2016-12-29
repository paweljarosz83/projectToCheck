using UnityEngine;
using System.Collections;

public class SpawnManagerPoolingDlaWyzszych : MonoBehaviour {
	
		public GameObject[] obj;



	private Vector3 originPosition;// = new Vector3(0,-0,0);
	  
	Color lightBlue = new Color (0.113f,0.204f,0.213f,1);

	    public ObjectPool objectPool;
	    //public CoinPool coinPool;

		private GameObject poprzedniElement;
		private GameObject nastepnyElement;

	    private GameObject coin1;
		private GameObject coin2;
		private GameObject coin3;
		private GameObject coin4;

		private bool pierwszy = true;
		public int aktualnaLiczbaPlatform;
		private int maksymalnaLiczbaPlatform = 5;
		
		public Vector3 nowaPozycja;
		
		void Start(){
		
		float ix = transform.position.x;
		float iy = transform.position.y;
		float iz = transform.position.z;

		originPosition = new Vector3(ix,iy,iz);
			//originPosition = transform.position;
			///Spawn();
		}



		void Update()
		{
			
			if (aktualnaLiczbaPlatform < maksymalnaLiczbaPlatform)
			{
				Spawn();
				aktualnaLiczbaPlatform++;
			}
		}
		
		void Spawn()
		{
			
			nastepnyElement = objectPool.getObiektZPuli();
			nastepnyElement.SetActive(true);
			
			if (pierwszy)
			{
				
				//Vector2 originPosition = new Vector2(0, 0);
				//Instantiate(nastepnyElement, originPosition, Quaternion.identity);
			nastepnyElement.transform.position = originPosition;
				pierwszy = false;
				
				poprzedniElement = nastepnyElement;
				
			}
			else
			{
				float randomowePrzesuniecieX = 5;
				float nowePrzesuniecieY = 0;

			    nowePrzesuniecieY = Random.Range(-2f, 2f);

			if (nowePrzesuniecieY >= 0) {
				randomowePrzesuniecieX = Random.Range (2.0f, 4.0f);
			} else {
				randomowePrzesuniecieX = Random.Range (2.0f, 5.0f);
			}
	
				
				//obliczenie o ile minimalnie musi się przesunac nastepny element zeby nie
				//nakladal sie z nastepnym
				
				float polSzerokosciPoprzedniego
					= (poprzedniElement.GetComponent<Renderer>().bounds.size.x) / 2;
				
				float polSzerokosciNastepnego
					= (nastepnyElement.GetComponent<Renderer>().bounds.size.x) / 2;
				
				float minimalnePrzesuniecieBezNakladania = polSzerokosciPoprzedniego + polSzerokosciNastepnego;
				
				//Vector2 nowaPozycja = originPosition +
				//	new Vector2 (minimalnePrzesuniecieBezNakladania+randomowePrzesuniecieX,nowePrzesuniecieY);
				
				nowaPozycja = originPosition +
				new Vector3(minimalnePrzesuniecieBezNakladania + randomowePrzesuniecieX, nowePrzesuniecieY,0);
				
				originPosition = nowaPozycja;
				poprzedniElement = nastepnyElement;
				
				nastepnyElement.transform.position = nowaPozycja;
				if (gameObject.tag == "bcg") {
				
				//nastepnyElement.GetComponent<Renderer> ().material.color = Color.gray;



				//nastepnyElement.GetComponent<Renderer> ().material.color = lightBlue;
				}


			}
		}
	}
