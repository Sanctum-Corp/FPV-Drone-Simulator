using UnityEngine;

public class DoorController : MonoBehaviour
{
	private void Start()
	{
		GameEvents.current.onDoorwayTriggerEnter += OnDoorOpen;
	}

	private void OnDoorOpen()
	{
		transform.Translate(Vector3.up * 10);
	}
}
