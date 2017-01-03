using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour 
{

	[Tooltip("Levelspielzeit in Sekunden")]public float playTime;

	[Tooltip("Buildindex der ersten Gameplay Scene")]public int playableLevelID;

	[HideInInspector]public float timeLeft;

	int sceneID; // check if Levelcountdown should be started

	GameObject ball;
	GameObject player;
	GameObject interactiveUI;

	Animator animatorUI;
	Animator animator;

	void Start()
	{
		SetupScene ();
	}

	void Update()
	{
		if (sceneID >= playableLevelID)
			LevelCountDown ();
	}

	void LevelCountDown()
	{
		float playedTime = Time.timeSinceLevelLoad;
		timeLeft = playTime - playedTime;

		if (playedTime >= playTime)
			SceneManager.LoadScene ("GameOver");
	}

	void SetupScene()
	{
		// Things to deactivate
		animator = GameObject.FindGameObjectWithTag ("Player").GetComponent<Animator>();
		animatorUI = GameObject.FindGameObjectWithTag ("InteractiveUI").GetComponent<Animator>();

		// Things to deactivate that MIGHT be there
		ball = GameObject.FindGameObjectWithTag ("Basketball");
		animatorUI.enabled = false;

		sceneID = SceneManager.GetActiveScene ().buildIndex;

		if (sceneID < playableLevelID) {
			Destroy (ball);
			animator.CrossFadeInFixedTime ("Idle", 0F);
			animatorUI.CrossFadeInFixedTime ("Idle", 0F);
		}

		if (sceneID == 1)
			ScoreManager.score = 0;

		if (sceneID >= playableLevelID) {
			animator.enabled = true;
			Player.lastVisitedScene = sceneID;
		}
	}
}
