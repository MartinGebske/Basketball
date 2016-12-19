using UnityEngine;
using System.Collections;

public class BallStreakEvents : MonoBehaviour {

	public static int scoreStreak;
	private LevelManager levelManager;
	private ScoreManager scoreManager;

	public delegate void OnScoreStrike ();
	public static event OnScoreStrike OnScoreStrikeEvent;

	void OnEnable()
	{
		Shredder.OnBallKilledEvent += this.ResetScoreStreak;
	}

	void OnDisable()
	{
		Shredder.OnBallKilledEvent -= this.ResetScoreStreak;
	}


	void Start () 
	{
		scoreStreak = 0;
		levelManager = FindObjectOfType<LevelManager> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	}

	public void UpdateScoring()
	{
		print ("scoreStreak = " + scoreStreak);
		switch (scoreStreak) 
		{
		case 0:
			break;
		case 1:
			break;
		case 2:
			break;
		case 3:
			levelManager.playTime += 5;
			OnScoreStrikeEvent ();
			break;
		case 4:
			break;
		case 5:
			scoreManager.IncrementScore(500);
			OnScoreStrikeEvent ();
			break;
		case 6:
			break;
		case 7:
			levelManager.playTime += 10;
			OnScoreStrikeEvent ();
			break;
		case 8:
			break;
		case 9:
			scoreManager.IncrementScore(1000);
			OnScoreStrikeEvent ();
			break;
		case 10:
			break;
		case 11:
			levelManager.playTime += 25;
			OnScoreStrikeEvent ();
			break;
		case 12:
			break;
		case 13:
			break;
		case 14:
			scoreManager.IncrementScore (2500);
			OnScoreStrikeEvent ();
			break;
		case 15:
			break;
		case 16:
			break;
		case 17:
			break;
		case 18:
			levelManager.playTime += 40;
			OnScoreStrikeEvent ();
			break;
		case 19:
			break;
		case 20:
			scoreManager.IncrementScore (5000);
			OnScoreStrikeEvent ();
			break;
		}
	}

	void ResetScoreStreak()
	{
		scoreStreak = 0;
		UpdateScoring ();
	}

}
