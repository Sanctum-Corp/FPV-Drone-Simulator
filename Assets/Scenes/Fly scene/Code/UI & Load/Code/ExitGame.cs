using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ExitGame : MonoBehaviour
{
	[SerializeField] Button exitButton;

	private void Start()
	{
		exitButton.onClick.AddListener(CloseGame);
	}

	private void CloseGame()
	{
		Application.Quit();
	}
}
