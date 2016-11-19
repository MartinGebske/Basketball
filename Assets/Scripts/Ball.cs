using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public static Ball DefaultInstance{
		get{ return ThisInstance; }
	}

	private static Ball ThisInstance = null;

	void Awake()
	{
		if (ThisInstance != null) {
			DestroyImmediate (gameObject);
			return;
		}
		ThisInstance = this;
	}
}
