using UnityEngine;
using System.Collections;

public class DetectScoring : MonoBehaviour {

    public int scorePerHit = 1;

	private GvrHUD hud;

	private ScoreManager scoreManager;


	void Start()
	{
		hud = FindObjectOfType<GvrHUD> ();
		scoreManager = FindObjectOfType<ScoreManager>();
	}

    void OnCollisionEnter(Collision collision)
    {
        scoreManager.IncrementScore(scorePerHit);
		hud.UpdateScore ();
    }
}
