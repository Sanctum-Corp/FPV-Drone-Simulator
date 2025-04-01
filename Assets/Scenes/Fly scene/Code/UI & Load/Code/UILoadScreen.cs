using UnityEngine;

public class UILoadScreen : MonoBehaviour
{
	private void Awake()
	{
		HideScreen();
	}

	public void ShowScreen()
	{
		gameObject.SetActive(true);
	}
	public void HideScreen()
	{
		gameObject.SetActive(false);
	}
}
