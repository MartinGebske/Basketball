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
		if (!isInPlay) {
			if (ballLauncher != null) {
				ballLauncher.GrabBall ();
			} else {
				ballLauncher = FindObjectOfType<BallLauncher> ();
				if (ballLauncher != null) {
					ballLauncher.GrabBall ();
				} else if (ballLauncher == null) {
					Debug.LogWarning ("Weird shit happened to the Ball Launcher o.O");
				}
			}
		}

	}
	public void OnGazeTrigger()
	{
	}
	public void OnGazeExit()
	{
	}

	public void ShowBall ()
	{
		if (animator == null) {
			animator = GetComponent<Animator> ();
		} else if(animator != null){
			animator.SetTrigger (anim_ShowBall);
		}
	
	}

	void OutOfGame()
	{
		if (animator != null) {
			animator.CrossFade ("Idle", 0);
		}
	}
}
