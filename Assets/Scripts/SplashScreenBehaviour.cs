using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class SplashScreenBehaviour : MonoBehaviour 
{

	public TextMeshProUGUI startingFeedback;

	public int timer = 10;

	public List<CanvasGroup> hideableGroups;


	void Start()
	{
		HideGroups ();
	}

	#region Show and Hide CanvasGroups

	public void HideGroups()
	{
		foreach (CanvasGroup group in hideableGroups) {
			group.alpha = 0;
			group.blocksRaycasts = false;
			group.interactable = false;
		}
	}

	public void ShowPanel(CanvasGroup panelName)
	{
		CanvasGroup demandedGroup = hideableGroups.Find (panel => string.Equals(panel.name, panelName));

		panelName.alpha = 1;
		panelName.blocksRaycasts = true;
		panelName.interactable = true;
	}

	#endregion

	#region Starting the Game

	public void InvokeStart()
	{
		StartCoroutine (CountdownToGame());
	}
		
	IEnumerator StartGame()
	{
		yield return new WaitForSeconds (0.5F);
		SceneManager.LoadScene (1);
	}

	IEnumerator CountdownToGame()
	{

		while (timer >= 0) {
			timer -= 1;

			if (timer > 5 && startingFeedback != null) {
				startingFeedback.text = "Please setup your Cardboard device.";
			}
			if (timer <= 5 && startingFeedback != null) {
				startingFeedback.text = "The game starts in... " + timer.ToString ();
			}

			if (timer == 0) {
				StartCoroutine(StartGame());
				break;
			}

			yield return new WaitForSeconds (1);

		}
	}
	#endregion
}
