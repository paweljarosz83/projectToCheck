using UnityEngine;
using System.Collections;

public class Preferences : MonoBehaviour {

	public static Preferences Instance;

	public static int soundSwith = 1;

	void Awake ()   
	{
		if (Instance == null)
		{
			DontDestroyOnLoad(gameObject);
			Instance = this;
		}
		else if (Instance != this)
		{
			Destroy (gameObject);
		}
	}

}
