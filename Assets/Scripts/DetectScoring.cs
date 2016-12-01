using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DetectScoring : MonoBehaviour {

    public int scorePerHit = 1;

	private GvrHUD hud;
	private ScoreSignDisplay[] scoreDisplay = new ScoreSignDisplay[2];

	private ScoreManager scoreManager;

	void Start()
	{
		foreach (var item in scoreDisplay) {
			scoreDisplay = FindObjectsOfType<ScoreSignDisplay> ();

		}

		hud = FindObjectOfType<GvrHUD> ();
		scoreManager = FindObjectOfType<ScoreManager>();
	}

    void OnCollisionEnter(Collision collision)
    {
        scoreManager.IncrementScore(scorePerHit);

		hud.scoreScreenMessage.text = scorePerHit.ToString();
		hud.ShowScreenMessage ();

		}

}
