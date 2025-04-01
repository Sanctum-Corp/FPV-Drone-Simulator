using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
	[SerializeField] private Button startButton;
	[SerializeField] private GameObject UI;

	private void Start()
	{
		startButton.onClick.AddListener(StartGameYo);
	}

	private void StartGameYo()
	{
		if (Time.timeScale == 0)
			Time.timeScale = 1;

		UI.gameObject.SetActive(false);
	}
}
