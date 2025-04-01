using UnityEngine;


public interface IFlying
{
	public abstract void Fly(Rigidbody rigidbody, float throttle, float roll, float pitch, float yaw, ScrProperties properties);
}
