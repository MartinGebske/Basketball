using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSignDisplay : MonoBehaviour 
{
	public Text timerText;
	public Text scoreText;

	private LevelManager levelManager;

	void Start()
	{
		levelManager = FindObjectOfType<LevelManager> ();
		UpdateScore ();
	}

	void Update()
	{
		timerText.text = levelManager.timeLeft.ToString("F");
	}

	public void UpdateScore()
	{
		scoreText.text = ScoreManager.score.ToString();
	}

}
