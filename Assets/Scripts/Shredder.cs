using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour 
{

	void OnTriggerEnter(Collider col)
	{
		Destroy (col.gameObject);
		Debug.Log ("destroyed");
		BallLauncher.ballLives = false;
	}

	public void DestroyBall()
	{
		GameObject ballToDestroy = GameObject.FindGameObjectWithTag ("Basketball");
		Destroy (ballToDestroy);
		Debug.Log ("destroyed old ball");
		BallLauncher.ballLives = false;
	}

}
