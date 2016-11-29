using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class GameOver : MonoBehaviour 
{
	public Text resultText;

	void Start()
	{
		resultText.text = ScoreManager.score.ToString();
	}

}
