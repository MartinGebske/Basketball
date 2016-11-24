using UnityEngine;
using System.Collections;

public class BallSpender : MonoBehaviour {

	public GameObject basketBall;

	void Start()
	{
		SpendNewBall ();
	}

	public void SpendNewBall()
	{
		Ball.isInPlay = false;
		// TODO: "Wir instanzieren nicht!" :) Aus Performance Gründen könnte der Ball einfach ausgeschaltet und platziert werden.
		GameObject newBall = Instantiate (basketBall, transform.position, Quaternion.identity) as GameObject;
	}

}
