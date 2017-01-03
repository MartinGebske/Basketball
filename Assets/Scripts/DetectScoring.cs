using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectScoring : MonoBehaviour {

    public int scorePerHit = 1;

	public Text scoreText;

	public static bool currentScoreRoutine;

	private ScoreManager scoreManager;

	private BallSpender ballSpender;

	private GameObject basketBall;

	private Rigidbody rb;

	private Animator animator;

	private AudioSource audioSource;

	static readonly int anim_HasScored = Animator.StringToHash("hasScored");

	public delegate void OnScoring ();
	public static event OnScoring OnScoreEvent;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();

		animator = GetComponentInChildren<Animator> ();

		basketBall = GameObject.FindGameObjectWithTag ("Basketball");
		rb = basketBall.GetComponent<Rigidbody> ();

		scoreManager = FindObjectOfType<ScoreManager>();
		ballSpender = FindObjectOfType<BallSpender> ();

		scoreText.text = scorePerHit.ToString ();
	}
		
	void OnTriggerEnter(Collider ballCol)
	{
		currentScoreRoutine = true;

		ScoreAction ();

		OnScoreEvent ();

		rb.isKinematic = true;

		StartCoroutine (WaitForBall());
	}

	void ScoreAction()
	{
		this.audioSource.Play ();

		animator.SetTrigger (anim_HasScored);

		// BUUUUG Wenn zum 5. mal gescored wurde. Hier geht es zum Score Manager und von da aus zum ScoreSignDisplay
		scoreManager.IncrementScore(scorePerHit);
	}

	IEnumerator WaitForBall()
	{
		yield return new WaitForSeconds (0.3F);

		currentScoreRoutine = false;
	
		ballSpender.SpendNewBall ();
	}
}
