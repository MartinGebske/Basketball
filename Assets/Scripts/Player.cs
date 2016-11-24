using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Singleton Pattern for the player
	public static Player player
	{
		get{return thisPlayer;}
	}

	private static Player thisPlayer = null;


	void Awake()
	{
		if (thisPlayer != null) {
			Destroy (gameObject);
		}
		thisPlayer = this;
		DontDestroyOnLoad (gameObject);
	}
}
