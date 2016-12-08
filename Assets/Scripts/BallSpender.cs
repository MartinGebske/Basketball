using UnityEngine;
using System.Collections;

public class BallSpender : MonoBehaviour {

	public GameObject basketBall;
	private Rigidbody rb;

	void Start()
	{
		rb = basketBall.GetComponent<Rigidbody> ();
		SpendNewBall ();
	}

	public void SpendNewBall()
	{
		
		basketBall.transform.position = this.transform.position;
		Ball.isInPlay = false;
	}
}
