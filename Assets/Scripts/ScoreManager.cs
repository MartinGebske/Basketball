using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static long score = 0;

	public ScoreSignDisplay[] displayArray;

    public void IncrementScore(long amount)
    {
        score += amount;

		foreach (ScoreSignDisplay disp in displayArray) {
			disp.UpdateScore ();
		}
    }

}
