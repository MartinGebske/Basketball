using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreSignDisplay : MonoBehaviour 
{
	public Text timerText;
	public Text scoreText;

	public ParticleSystem fireworks;

	private LevelManager levelManager;

	void OnEnable()
	{
		PlayerPrefsManager.OnHighscoreEvent += this.FireParticle;
	}

	void OnDisable()
	{
		PlayerPrefsManager.OnHighscoreEvent -= this.FireParticle;
	}


	void Start()
	{
		fireworks.Stop ();
		fireworks.Clear ();

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

	public void FireParticle()
	{
		fireworks.Play ();
	}
}
