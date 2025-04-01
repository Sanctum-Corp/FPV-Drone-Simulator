using UnityEngine;

[CreateAssetMenu(fileName = "Fly properties", menuName = "Properties/Fly Properties")]
public class ScrProperties : ScriptableObject
{
	[SerializeField] public float weight = 0.75f;


	[SerializeField] public float throttlePower = 10f;
	[SerializeField] public float rotationSpeed = 0.25f;
	[SerializeField] public float stabilizationForce = 0.1f;
}
