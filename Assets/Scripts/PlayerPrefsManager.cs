using UnityEngine;
using System.Collections;

public class PlayerPrefsManager : MonoBehaviour 
{
	public Settings playerSettings;

	void OnEnable()
	{
		DetectScoring.OnScoreEvent += this.ManageHighscore;
	}

	void OnDisable()
	{
		DetectScoring.OnScoreEvent  -= this.ManageHighscore;
	}

	//#if UNITY_EDITOR

	// TODO: Just for Debug Purpose: Deletes Values in PlayerPrefs.... obviously. -.-

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F12)){
			PlayerPrefs.DeleteAll ();
			Debug.LogWarning("PlayerPrefs deleted!");
			}
	}
	//#endif

	void SaveSettings(Settings settings)
	{
		PlayerPrefs.SetInt ("Highscore", ScoreManager.score);
	}

	Settings LoadSettings()
	{
		var resultSettings = new Settings ();

		resultSettings.highscore = PlayerPrefs.GetInt ("Highscore", 0);

		return resultSettings;
	}

	void ManageHighscore()
	{
		int currentHighscore = PlayerPrefs.GetInt ("Highscore");

		if (ScoreManager.score > currentHighscore) {
			SaveSettings(playerSettings);
		}


	}
}
