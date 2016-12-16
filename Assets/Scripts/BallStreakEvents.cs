using UnityEngine;
using System.Collections;

public class BallStreakEvents : MonoBehaviour {

	public static int scoreStreak;
	private LevelManager levelManager;

	void Start () 
	{
		scoreStreak = 0;
		levelManager = FindObjectOfType<LevelManager> ();
	}

	public void UpdateScoring()
	{
		switch (scoreStreak) 
		{
		case 1:
			break;
		case 2:
			break;
		case 3:
			levelManager.playTime += 5;
			break;
		case 4:
			break;
		case 5:
			break;
		}
	}
}
