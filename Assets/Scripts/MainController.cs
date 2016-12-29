using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainController : MonoBehaviour {

	private static MainController mainController;

	private AsyncOperation resourceUnloadTask;
	private AsyncOperation sceneLoadTask;

	private static bool reload = true;
	private static string sceneToLoad;

	protected void Awake(){
		Object.DontDestroyOnLoad (gameObject);
		mainController = this;
		sceneToLoad = "lobby";
	}

	protected void Update(){
		if (reload) {
			krok1 ();
			reload = false;
		}
	}

	private void krok1(){
		System.GC.Collect();
		krok2 ();
	}

	private void krok2(){
		sceneLoadTask = Application.LoadLevelAsync (sceneToLoad);
		if (sceneLoadTask.isDone) {
			krok3 ();
		}
	}

	private void krok3(){
		if (resourceUnloadTask == null) {
			resourceUnloadTask = Resources.UnloadUnusedAssets ();
		} else {
			if (resourceUnloadTask.isDone == true) {
				resourceUnloadTask = null;
				krok4 ();
			}
		}
	}

	private void krok4(){
		SceneManager.LoadScene (sceneToLoad);
	}

	public static void SwitchScene(string nextScene){
		reload = true;
		sceneToLoad = nextScene;
	}
}








