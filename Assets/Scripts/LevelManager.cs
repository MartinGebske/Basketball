using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour 
{

	[Tooltip("Levelspielzeit in Sekunden")]public float playTime;

	[Tooltip("Buildindex der ersten Gameplay Scene")]public int playableLevelID;

	int sceneID; // check if Levelcountdown should be started

	GameObject scoreDisplayer;
	Text scoreText;

	GameObject ball;
	GameObject ring;
	GameObject player;
	GameObject interactiveUI;

	Animator animatorUI;
	Animator animator;

	void Start()
	{
		SetupScene ();

		playTime = playTime;
	}

	void Update()
	{
		if (sceneID >= playableLevelID)
			LevelCountDown ();
	}

	void LevelCountDown()
	{
		if (playTime <= Time.timeSinceLevelLoad) {
			SceneManager.LoadScene ("GameOver");
		}
	}

	void SetupScene()
	{
		// Things to deactivate
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator>();
		animatorUI = GameObject.FindGameObjectWithTag ("InteractiveUI").GetComponent<Animator>();
		scoreText = GameObject.FindGameObjectWithTag ("Scoretext").GetComponent<Text> ();

		// Things to deactivate that MIGHT be there
		ball = GameObject.FindGameObjectWithTag ("Basketball");
		ring = GameObject.FindGameObjectWithTag ("Ring");

		sceneID = SceneManager.GetActiveScene ().buildIndex;

		if (sceneID < playableLevelID) {
			Destroy (ball);
			animator.CrossFadeInFixedTime ("Idle", 0F);
			animatorUI.CrossFadeInFixedTime ("Idle", 0F);

			string tempString = "";
			scoreText.text = tempString;
		}

		if (sceneID == 1)
			ScoreManager.score = 0;

		if (sceneID >= playableLevelID) {
			animator.enabled = true;
			scoreText.text = ScoreManager.score.ToString();
		}
	}
}
