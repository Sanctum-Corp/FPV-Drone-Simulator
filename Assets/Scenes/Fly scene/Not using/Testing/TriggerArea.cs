using UnityEngine;

public class TriggerArea : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		GameEvents.current.DoorwayTriggerEnter();

		var obj = Instantiate(new GameObject("j"));
		obj.AddComponent<GameEvents>();
		obj.GetComponent<GameEvents>().DoorwayTriggerEnter();
	}
}
