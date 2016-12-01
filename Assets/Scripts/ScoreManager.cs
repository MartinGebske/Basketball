using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static long score = 0;

	public ScoreSignDisplay disp1;
	public ScoreSignDisplay disp2;
	public ScoreSignDisplay disp3;
	public ScoreSignDisplay disp4;


    public void IncrementScore(long amount)
    {
        score += amount;

		disp1.UpdateScore ();
		disp2.UpdateScore ();
		disp3.UpdateScore ();
		disp4.UpdateScore ();
    }
}
