using UnityEngine;

public class DroneAcroFlyComponent : AbstFlyComponent, IFlying
{
	private const float THROTTLE_LIMIT_MIN = 0.0f;
	private const float THROTTLE_LIMIT_MAX = 1.0f;

	[SerializeField] private Rigidbody rb;

	private bool ActiveEventCalled;

	public override void Fly(Rigidbody rigidbody, float throttle, float roll, float pitch, float yaw, ScrProperties properties)
	{
		// נואכ³חאצ³ÿ
		throttle = Mathf.Clamp(throttle, THROTTLE_LIMIT_MIN, THROTTLE_LIMIT_MAX);

		EngineActive = throttle > 0.01 || throttle < -0.01f;

		rigidbody.AddForce(transform.up * throttle * properties.throttlePower, ForceMode.Force);

		rigidbody.AddTorque(transform.right * pitch * properties.rotationSpeed, ForceMode.Force);
		rigidbody.AddTorque(transform.forward * -roll * properties.rotationSpeed, ForceMode.Force);

		rigidbody.AddTorque(transform.up * yaw * properties.rotationSpeed, ForceMode.Force);

		rigidbody.AddTorque(transform.right * -rigidbody.angularVelocity.x * properties.stabilizationForce, ForceMode.Force);
		rigidbody.AddTorque(transform.forward * -rigidbody.angularVelocity.z * properties.stabilizationForce, ForceMode.Force);

		CallEvents();
	}

	protected override void CallEvents()
	{
		if (rb.velocity.magnitude > 0.05f && EngineActive && !ActiveEventCalled)
		{
			//Debug.Log("Started flying audio");
			startedFlying?.Invoke();
			ActiveEventCalled = true;
		}
		else if (rb.velocity.magnitude > 0.05f && !EngineActive && ActiveEventCalled)
		{
			//Debug.Log("Started falling audio");
			stoppedFlying?.Invoke();
			ActiveEventCalled = false;
		}
	}
}
