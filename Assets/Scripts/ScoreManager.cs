using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static int score = 0;

	public ScoreSignDisplay[] displayArray;

    public void IncrementScore(int amount)
    {
        score += amount;

		foreach (ScoreSignDisplay disp in displayArray) {
			disp.UpdateScore ();
		}
    }
}
