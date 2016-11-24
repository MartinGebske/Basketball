using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score = 0;

    public void IncrementScore(int amount)
    {
        score += amount;
    }
}
