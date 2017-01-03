using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Ball : MonoBehaviour, IGvrGazeResponder {

	private BallLauncher ballLauncher;

	private Animator animator;

	public static bool isInPlay;

	static readonly int anim_ShowBall = Animator.StringToHash("ballAppear");

	void OnEnable()
	{
		Shredder.OnBallKilledEvent += this.OutOfGame;
		DetectScoring.OnScoreEvent += this.OutOfGame;
		BallSpender.OnSpawnNewBallEvent += this.ShowBall;

	}

	void OnDisable()
	{
		Shredder.OnBallKilledEvent -= this.OutOfGame;
		DetectScoring.OnScoreEvent -= this.OutOfGame;
		BallSpender.OnSpawnNewBallEvent -= this.ShowBall;
	}

	void Start()
	{
		ballLauncher = FindObjectOfType<BallLauncher> ();
		animator = GetComponent<Animator> ();
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

	public void ShowBall ()
	{
		animator.SetTrigger (anim_ShowBall);
	}

	void OutOfGame()
	{
		animator.CrossFade ("Idle", 0);
	}
}
