using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLoadingScene
{

	private Coroutines coroutines;
	private UILoadScreen loadScreen;


	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	public static void Main()
	{
		LoadLoadingScene instance = new LoadLoadingScene();
		instance.RunAll();
	}

	private LoadLoadingScene()
	{
		coroutines = new GameObject("COROUTINES").AddComponent<Coroutines>();
		GameObject.DontDestroyOnLoad(coroutines.gameObject);

		var load = Resources.Load<UILoadScreen>("MyUI");
		loadScreen = GameObject.Instantiate(load);
		GameObject.DontDestroyOnLoad(loadScreen.gameObject);
	}

	private void RunAll()
	{
		coroutines.StartCoroutine(LoadMenu());
	}

	private IEnumerator LoadMenu()
	{
		SceneManager.LoadScene(DroneSimulatorScenes.LOADING_SCENE);
		loadScreen.ShowScreen();
		yield return new WaitForSeconds(1);
		yield return SceneManager.LoadSceneAsync(DroneSimulatorScenes.GAME_SCENE);
		loadScreen.HideScreen();
	}
}
