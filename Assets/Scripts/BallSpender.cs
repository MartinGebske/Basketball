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
		basketBall.transform.position = this.transform.position;
		Ball.isInPlay = false;
	}
}
