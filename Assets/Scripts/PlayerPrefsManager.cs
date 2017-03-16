using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour 
{
	public Settings playerSettings;

	int currentHighscore;

	bool freshRun = true;

	// Refactor... for good.
	public delegate void OnNewHighscore();
	public static event OnNewHighscore OnHighscoreEvent;

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

		freshRun = true;
	}

	// TODO: Just for Debug Purpose: Deletes Values in PlayerPrefs.... obviously. -.- Should be attached to specific
	// PlayerPrefsKiller GameObject.

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F12)){
			PlayerPrefs.DeleteAll ();
			Debug.LogWarning("PlayerPrefs deleted!");
			}
	}

	void SaveSettings(Settings settings)
	{
		if (settings != null) {
			settings.highscore = ScoreManager.score;
			settings.run = 1;
			PlayerPrefs.SetInt ("HIGHSCORE", settings.highscore);
			PlayerPrefs.SetInt ("RUN", settings.run);
		} else {
			Debug.LogError ("Settings is null!");
		}
	}

	Settings LoadSettings()
	{
		var resultSettings = new Settings ();

		resultSettings.highscore = PlayerPrefs.GetInt ("HIGHSCORE");
		resultSettings.run = PlayerPrefs.GetInt ("RUN");

		return resultSettings;
	}

	void ManageHighscore()
	{
		if (playerSettings.run > 0) {

			if (freshRun) {
				if (ScoreManager.score > currentHighscore) {
					print ("New Highscore Reached! " + ScoreManager.score);
					OnHighscoreEvent ();
					// Just for safety, store the new Highscore immediately!
					SavingHighscore ();

					freshRun = false;
				}
			}
		}
	}

	void SavingHighscore()
	{
		SaveSettings (playerSettings);
		Debug.Log("PlayerPrefs saved!");
	}
}
