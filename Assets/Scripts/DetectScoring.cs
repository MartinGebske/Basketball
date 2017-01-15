using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectScoring : MonoBehaviour {

	public int basketNumber;

    public int scorePerHit = 1;

	public Text scoreText;

	public ParticleSystem scoreParticles;

	public static bool currentScoreRoutine;

	private ScoreManager scoreManager;

	private BallSpender ballSpender;

	private GameObject basketBall;

	private Rigidbody rb;

	private Animator animator;

	static readonly int anim_HasScored = Animator.StringToHash("hasScored");

	public delegate void OnScoring ();
	public static event OnScoring OnScoreEvent;


	void OnEnable()
	{
		ScoreApplyer.OnBallPassEvent += this.PlayerHasScored;
	}

	void OnDisable()
	{
		ScoreApplyer.OnBallPassEvent -= this.PlayerHasScored;
	}
		
	void Start()
	{
		scoreParticles.Stop ();
		scoreParticles.Clear ();

		animator = GetComponentInChildren<Animator> ();
		animator.enabled = false;

		basketBall = GameObject.FindGameObjectWithTag ("Basketball");
		rb = basketBall.GetComponent<Rigidbody> ();

		scoreManager = FindObjectOfType<ScoreManager>();
		ballSpender = FindObjectOfType<BallSpender> ();

		scoreText.text = scorePerHit.ToString ();
	}
		
	void PlayerHasScored(int number)
	{
		if (number == basketNumber) {

			// Waits for the Ball to spend.
			currentScoreRoutine = true;

			ScoreAction ();

			OnScoreEvent ();

			rb.isKinematic = true;

			StartCoroutine (WaitForBall ());
		}
	}

	void ScoreAction()
	{
		animator.enabled = true;
		animator.SetTrigger (anim_HasScored);

		scoreParticles.Play ();

		scoreManager.IncrementScore(scorePerHit);
	}

	IEnumerator WaitForBall()
	{
		yield return new WaitForSeconds (0.3F);

		currentScoreRoutine = false;
	
		ballSpender.SpendNewBall ();
	}
}
