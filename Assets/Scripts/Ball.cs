using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour, IGvrGazeResponder {


	// Singleton declaration
	public static Ball DefaultInstance{
		get{ return ThisInstance; }
	}

	private static Ball ThisInstance = null;

	private BallLauncher ballLauncher;

	void Awake()
	{
		if (ThisInstance != null) {
			DestroyImmediate (gameObject);
			return;
		}
		ThisInstance = this;

		ballLauncher = FindObjectOfType<BallLauncher> ();
	}



	public void OnGazeEnter()
	{
		ballLauncher.GrabBall ();
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
