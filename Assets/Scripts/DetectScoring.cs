using UnityEngine;
using System.Collections;

public class DetectScoring : MonoBehaviour {

    public int scorePerHit = 1;


    void OnCollisionEnter(Collision collision)
    {
		ScoreManager scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.IncrementScore(scorePerHit);
    }
}
