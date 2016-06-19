using UnityEngine;
using System.Collections;

public class SpawnManagerPoolingDlaWyzszych : MonoBehaviour {
	
		public GameObject[] obj;
	private Vector2 originPosition = new Vector2(0,-5);
	    public ObjectPool objectPool;
	    public CoinPool coinPool;

		private GameObject poprzedniElement;
		private GameObject nastepnyElement;

	    private GameObject coin1;
		private GameObject coin2;
		private GameObject coin3;
		private GameObject coin4;

		private bool pierwszy = true;
		public int aktualnaLiczbaPlatform;
		private int maksymalnaLiczbaPlatform = 5;
		
		public Vector2 nowaPozycja;
		
		void Start()
		{
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

			    nowePrzesuniecieY = Random.Range(2f, 2f);

			if (nowePrzesuniecieY >= 0) {
				randomowePrzesuniecieX = Random.Range (2.0f, 5.0f);
			} else {
				randomowePrzesuniecieX = Random.Range (2.0f, 7.0f);
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
					new Vector2(minimalnePrzesuniecieBezNakladania + randomowePrzesuniecieX, nowePrzesuniecieY);
				
				originPosition = nowaPozycja;
				poprzedniElement = nastepnyElement;
				
				nastepnyElement.transform.position = nowaPozycja;






			/*
			float randomoweWyniesienieCoinNaY = Random.Range(5.5f, 7.0f);


			    coin1 = coinPool.getObiektZPuli ();
				coin1.SetActive (true);
			coin1.transform.position = nowaPozycja + new Vector2 (-0.6f, randomoweWyniesienieCoinNaY);

			randomoweWyniesienieCoinNaY = Random.Range(5.5f, 7.0f);

				coin2 = coinPool.getObiektZPuli ();
				coin2.SetActive (true);
			coin2.transform.position = nowaPozycja + new Vector2 (0f, randomoweWyniesienieCoinNaY);

			randomoweWyniesienieCoinNaY = Random.Range(5.5f, 7.0f);

				coin3 = coinPool.getObiektZPuli ();
				coin3.SetActive (true);
			coin3.transform.position = nowaPozycja + new Vector2 (0.6f, randomoweWyniesienieCoinNaY);
			*/
			}
		}
	}
