using System;
using UnityEngine;

[Serializable]
public abstract class AbstFlyComponent : MonoBehaviour, IFlying
{
	public delegate void FlyEvents();
	public FlyEvents startedFlying;
	public FlyEvents stoppedFlying;

	public bool EngineActive { get; protected set; }
	public abstract void Fly(Rigidbody rigidbody, float throttle, float roll, float pitch, float yaw, ScrProperties properties);
	protected abstract void CallEvents();
}
