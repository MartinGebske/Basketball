using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour 
{
	public Settings playerSettings;

	int currentHighscore;

	void OnEnable()
	{
		DetectScoring.OnScoreEvent += this.ManageHighscore;
		GameOver.OnGameOverEvent += this.SavingHighscore;
	}

	void OnDisable()
	{
		DetectScoring.OnScoreEvent  -= this.ManageHighscore; // Obacht! Speichert aktuell bei jedem Score! Soll nicht!
		GameOver.OnGameOverEvent -= this.SavingHighscore;
	}

	void Start()
	{
		playerSettings = LoadSettings ();
		Debug.Log("PlayerPrefs loaded!");

		currentHighscore = playerSettings.highscore;

	}

	// TODO: Just for Debug Purpose: Deletes Values in PlayerPrefs.... obviously. -.-

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F12)){
			PlayerPrefs.DeleteAll ();
			Debug.LogWarning("PlayerPrefs deleted!");
			}
	}

	void SaveSettings(Settings settings)
	{
		settings.highscore = ScoreManager.score;
		PlayerPrefs.SetInt ("HIGHSCORE", settings.highscore);
	}

	Settings LoadSettings()
	{
		var resultSettings = new Settings ();

		resultSettings.highscore = PlayerPrefs.GetInt ("HIGHSCORE");

		return resultSettings;
	}

	void ManageHighscore()
	{
		// Yeah... works ... kinda. But of course now the new Highscore Reached event is triggered all the time after the
		// Highscore is beaten. This should happen ONCE it's done (add a bool?) and then ... the next time the level is loaded.
		if (ScoreManager.score > currentHighscore) {
			print ("New Highscore Reached! " + ScoreManager.score);
		}
	}

	void SavingHighscore()
	{
		SaveSettings (playerSettings);
		Debug.Log("PlayerPrefs saved!");
	}
}
