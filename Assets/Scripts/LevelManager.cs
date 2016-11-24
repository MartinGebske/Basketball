using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour 
{

	[Tooltip("Levelspielzeit in Sekunden")]public float playTime;

	int sceneID; // check if Levelcountdown should be started


	void Awake()
	{
		sceneID = SceneManager.GetActiveScene ().buildIndex;
		playTime = playTime;
	}

	void FixedUpdate()
	{
		if (sceneID > 0)
			LevelCountDown ();
	}

	void LevelCountDown()
	{
		if (playTime <= Time.timeSinceLevelLoad) {
			SceneManager.LoadScene ("GameOver");
		}
	}
}
