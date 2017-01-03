using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SplashScreenSetup : MonoBehaviour 
{
	void Awake()
	{
		StartCoroutine (LoadGame ());
	}
	IEnumerator LoadGame()
	{
		yield return new WaitForSeconds (2);
		SceneManager.LoadScene (1);
	}
}
