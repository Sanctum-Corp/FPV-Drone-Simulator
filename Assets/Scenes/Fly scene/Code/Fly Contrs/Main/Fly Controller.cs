using UnityEngine;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Rigidbody))]
public class FlyController : MonoBehaviour
{

	private FlyInput inputActions;

	// Main input actions
	private InputAction throttle;
	private InputAction roll;
	private InputAction pitch;
	private InputAction yaw;


	[SerializeField] private Rigidbody rigidBody;

	[SerializeField] private ScrProperties properties;
	[SerializeField] private AbstFlyComponent flyComponent;
	[SerializeField] private Transform startPos;
	[SerializeField] private GameObject UI;

	private void Start()
	{
		if (rigidBody == null)
		{
			rigidBody = GetComponent<Rigidbody>();
		}
		transform.position = startPos.position;
	}
	private void Awake()
	{
		inputActions = new FlyInput();
		InitializeMainInputActions();
	}
	private void OnEnable()
	{
		inputActions.Enable();
		inputActions.MainInput.Restart.performed += (ctx) =>
		{
			transform.position = startPos.position;
			transform.rotation = Quaternion.identity;
			rigidBody.angularVelocity = Vector3.zero;
			rigidBody.velocity = Vector3.zero;

		};
		inputActions.MainInput.ToMenu.performed += (ctx) =>
		{
			if (UI.activeSelf)
			{
				UI.SetActive(false);
				Time.timeScale = 0f;
			}
			else
			{
				UI.SetActive(true);
				Time.timeScale = 1f;
			}

		};
	}
	private void OnDisable()
	{
		inputActions.Disable();
	}

	private void FixedUpdate()
	{
		float throttleForce = throttle.ReadValue<float>();
		float rollForce = roll.ReadValue<float>();
		float pitchForce = pitch.ReadValue<float>();
		float yawForce = yaw.ReadValue<float>();


		flyComponent.Fly(rigidBody, throttleForce, rollForce, pitchForce, yawForce, properties);
	}

	private void InitializeMainInputActions()
	{
		throttle = inputActions.MainInput.Throttle;
		roll = inputActions.MainInput.Roll;
		pitch = inputActions.MainInput.Pitch;
		yaw = inputActions.MainInput.Yaw;
	}
}
