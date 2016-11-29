using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour 
{

	[Tooltip("Levelspielzeit in Sekunden")]public float playTime;

	[Tooltip("Buildindex der ersten Gameplay Scene")]public int playableLevelID;

	int sceneID; // check if Levelcountdown should be started

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
		player = GameObject.FindGameObjectWithTag ("Player");
		interactiveUI = GameObject.FindGameObjectWithTag ("InteractiveUI");

		ball = GameObject.FindGameObjectWithTag ("Basketball");
		ring = GameObject.FindGameObjectWithTag ("Ring");
		animatorUI = interactiveUI.GetComponent<Animator> ();
		animator = player.GetComponent<Animator> ();

		sceneID = SceneManager.GetActiveScene ().buildIndex;
		if (sceneID < playableLevelID) {
			Destroy (ball);
			animator.CrossFadeInFixedTime ("Idle", 0F);
			animatorUI.CrossFadeInFixedTime ("Idle", 0F);
		}

		if (sceneID >= playableLevelID)
			animator.enabled = true;
	}

}
