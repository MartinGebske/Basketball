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
		basketBall.transform.position = this.transform.position;

	}

}
