using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectScoring : MonoBehaviour {

    public int scorePerHit = 1;

	public Text scoreText;

	private ScoreManager scoreManager;

	private BallSpender ballSpender;

	private GameObject basketBall;

	private Rigidbody rb;

	private Animator animator;

	void Start()
	{
		animator = GetComponentInChildren<Animator> ();

		basketBall = GameObject.FindGameObjectWithTag ("Basketball");
		rb = basketBall.GetComponent<Rigidbody> ();

		scoreManager = FindObjectOfType<ScoreManager>();
		ballSpender = FindObjectOfType<BallSpender> ();

		scoreText.text = scorePerHit.ToString ();

	}
		
	void OnTriggerEnter(Collider ballCol)
	{
		ScoreAction ();

		rb.isKinematic = true;

		// ggf. in Animation auslagern?
		ballSpender.SpendNewBall ();
	}

	void ScoreAction()
	{
		animator.SetTrigger ("hasScored");

		scoreManager.IncrementScore(scorePerHit);

		Ball.scoreStreak++;
	}
}
