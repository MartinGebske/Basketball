using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Singleton Pattern for the player
	public static Player player
	{
		get{return thisPlayer;}
	}

	public AudioClip throwSound;

	public static int lastVisitedScene;

	private AudioSource audioSource;

	private static Player thisPlayer = null;

	void Awake()
	{
		if (thisPlayer != null) {
			Destroy (gameObject);
		}
		thisPlayer = this;
		DontDestroyOnLoad (gameObject);
		audioSource = GetComponentInChildren<AudioSource> ();
	}
		
	public void PlayThrowSound()
	{
		audioSource.PlayOneShot (throwSound);
	}
}
