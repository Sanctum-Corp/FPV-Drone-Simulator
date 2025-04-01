using UnityEngine;


public class DroneAudioFlyingManager : MonoBehaviour
{
	
	[SerializeField] private AbstFlyComponent flyComponent;
	[SerializeField] private AudioSource flyAudioSourse;
	[SerializeField] private AudioSource fallAudioSourse;

	private void OnEnable()
	{
		flyComponent.startedFlying += PlayFlyingAudio;
		flyComponent.stoppedFlying += PlayFallingAudio;
	}

	private void PlayFlyingAudio()
	{
		//Debug.Log("Started flying audio");
		fallAudioSourse.Stop();
		flyAudioSourse.Play();
	}
	private void PlayFallingAudio() 
	{
		//Debug.Log("Started falling audio");
		flyAudioSourse.Stop();
		fallAudioSourse.Play();
	}
}
