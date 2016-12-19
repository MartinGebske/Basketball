using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectScoring : MonoBehaviour {

    public int scorePerHit = 1;

	public Text scoreText;

	public static bool currentScoreRoutine;

	private ScoreManager scoreManager;

	private BallSpender ballSpender;

	private BallStreakEvents ballEvents;

	private GameObject basketBall;

	private Rigidbody rb;

	private Renderer rend;

	private Animator animator;

	private AudioSource audioSource;

	static readonly int anim_HasScored = Animator.StringToHash("hasScored");

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();

		animator = GetComponentInChildren<Animator> ();

		basketBall = GameObject.FindGameObjectWithTag ("Basketball");
		rb = basketBall.GetComponent<Rigidbody> ();
		rend = basketBall.GetComponent<Renderer> ();

		scoreManager = FindObjectOfType<ScoreManager>();
		ballSpender = FindObjectOfType<BallSpender> ();
		ballEvents = FindObjectOfType<BallStreakEvents> ();

		scoreText.text = scorePerHit.ToString ();
	}
		
	void OnTriggerEnter(Collider ballCol)
	{
		currentScoreRoutine = true;

		ScoreAction ();

		rb.isKinematic = true;

		StartCoroutine (WaitForBall());
	}

	void ScoreAction()
	{
		this.audioSource.Play ();

		rend.enabled = false;

		animator.SetTrigger (anim_HasScored);

		scoreManager.IncrementScore(scorePerHit);
	
		BallStreakEvents.scoreStreak++;

		ballEvents.UpdateScoring ();
	
	}

	IEnumerator WaitForBall()
	{
		yield return new WaitForSeconds (0.3F);

		currentScoreRoutine = false;
	
		ballSpender.SpendNewBall ();
	}
}
