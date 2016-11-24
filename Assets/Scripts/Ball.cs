using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour, IGvrGazeResponder {

	private BallLauncher ballLauncher;

	public static bool isInPlay;

	void Start()
	{
		ballLauncher = FindObjectOfType<BallLauncher> ();
	}
		

	public void OnGazeEnter()
	{
		Debug.Log ("Enter");

		if(!isInPlay)
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
