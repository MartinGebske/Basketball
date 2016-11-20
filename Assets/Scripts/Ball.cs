using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour, IGvrGazeResponder {

	public static Ball DefaultInstance{
		get{ return ThisInstance; }
	}

	private static Ball ThisInstance = null;

	private GvrReticle reticle;

	void Awake()
	{
		if (ThisInstance != null) {
			DestroyImmediate (gameObject);
			return;
		}
		ThisInstance = this;
	}



	public void OnGazeEnter()
	{
		Debug.Log ("Enter");
	}
	public void OnGazeTrigger()
	{
		Debug.Log ("Trigger");
	}
	public void OnGazeExit()
	{
		Debug.Log ("Exit");
	}
}
