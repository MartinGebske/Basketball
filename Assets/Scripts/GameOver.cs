using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameOver : MonoBehaviour 
{
	public Text resultText;


	public delegate void OnGameOver();
	public static event OnGameOver OnGameOverEvent;

	void Start()
	{
		resultText.text = ScoreManager.score.ToString();
		OnGameOverEvent ();

	}

}
