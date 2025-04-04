using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
	public static GameEvents current;

	private void Awake()
	{
		current = this;
	}

	public event Action onDoorwayTriggerEnter;
	public void DoorwayTriggerEnter()
	{
		if (onDoorwayTriggerEnter != null)
		{
			onDoorwayTriggerEnter();
		}
	}
}
