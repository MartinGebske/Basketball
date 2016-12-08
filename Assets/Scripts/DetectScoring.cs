using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectScoring : MonoBehaviour {

    public int scorePerHit = 1;

	public Collider enterCollider;

	private ScoreManager scoreManager;

	private BallSpender ballSpender;

	private GameObject basketBall;

	private Rigidbody rb;

	void Start()
	{
		basketBall = GameObject.FindGameObjectWithTag ("Basketball");
		rb = basketBall.GetComponent<Rigidbody> ();

		scoreManager = FindObjectOfType<ScoreManager>();
		ballSpender = FindObjectOfType<BallSpender> ();

	}



	void OnTriggerEnter(Collider ballCol)
	{
		rb.isKinematic = true;

        scoreManager.IncrementScore(scorePerHit);

		Ball.scoreStreak++;

		ballSpender.SpendNewBall ();
	}

}
