using UnityEngine;
using System.Collections;

public class TutorialLogic : SplashScreenBehaviour 
{
	public CanvasGroup startCanvas;

	public void Start()
	{
		HideGroups ();
		startCanvas.alpha = 1;
		startCanvas.blocksRaycasts = true;
		startCanvas.interactable = true;
	}
}
