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
		if(!isInPlay)
		ballLauncher.GrabBall ();
	}
	public void OnGazeTrigger()
	{
	}
	public void OnGazeExit()
	{
	}
}
