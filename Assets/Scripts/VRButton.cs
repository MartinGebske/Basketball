using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class VRButton : MonoBehaviour, IGvrGazeResponder 
{
	// Jeder Button hat eine Animation attached. Wenn diese Animation abgelaufen ist
	// soll der Button ausgelöst sein.
	// Bei der Levelauswahl etwa: Y Position anheben (Schraube nach oben....) und Textur einfaden...
	// GGf. kann dann noch ein Playbutton oder "Start" Text darüber erscheinen. Damit es deutlich ist, was
	// man macht.

	Animator animator;

	public string sceneToLoad;

	void Start()
	{
		// Get Animator
	
	}


	public void OnGazeEnter()
	{
		// Senden welche Szene das Objekt darstelt.
		// Starten der Animation
		// Wenn die Animation fertig ist Szene starten

		if (sceneToLoad == "") {
			SceneManager.LoadScene (Player.lastVisitedScene);
		}
		else	
		SceneManager.LoadScene(sceneToLoad);
	}

	public void OnGazeTrigger() 
	{
		// Nothing in here	
	}

	public void OnGazeExit()
	{
		// Wenn die Animation nicht fertig ist, soll sie in den Idlezustand (also nichts tun) zurückgesetzt werden.
	}
}
