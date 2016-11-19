using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour 
{
	void OnTriggerEnter(Collider col)
	{
		Destroy (col.gameObject);
		Debug.Log ("destroyed");
	}

	//Debug! Aktuell wird der Ball im BallLauncher immer wieder zerstört! TODO
	public void DestroyBall()
	{
		GameObject ballToDestroy = GameObject.FindGameObjectWithTag ("Basketball");
		Destroy (ballToDestroy);

	}

}
