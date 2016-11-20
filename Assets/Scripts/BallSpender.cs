using UnityEngine;
using System.Collections;

public class BallSpender : MonoBehaviour {

	public GameObject basketBall;

	private Ball ball;

	void Update()
	{
		// Creates a new Ball automaticly after Ball died.
		FindObjectOfType<Ball> ();

		if (ball == null) 
		{
			SpendNewBall ();
		} 
	}

	public void SpendNewBall()
	{
		basketBall.transform.position = transform.position;
		GameObject newBall = Instantiate (basketBall, transform.position, Quaternion.identity) as GameObject;
	}

}
