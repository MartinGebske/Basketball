using UnityEngine;
using System.Collections;

public class Bouncing : MonoBehaviour 
{

	public delegate void OnCollision ();
	public static event OnCollision OnCollisionEvent;

	void OnCollisionEnter(Collision collision)
	{
		if (OnCollisionEvent != null) {
			OnCollisionEvent ();
		}
	}
}
