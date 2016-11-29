using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static long score = 0;

    public void IncrementScore(long amount)
    {
        score += amount;
    }
}
