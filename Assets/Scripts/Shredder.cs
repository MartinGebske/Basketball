using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour 
{
	//[Range(5,10)]public float killTime;

	private BallSpender ballSpender;

	private GameObject basketBall;

	public delegate void OnBallKilled();
	public static event OnBallKilled OnBallKilledEvent;

	void Start()
	{
		basketBall = GameObject.FindGameObjectWithTag ("Basketball");

		ballSpender = FindObjectOfType<BallSpender> ();
		//if (killTime < 5)
		//	killTime = 5;
	}

	/*void Update()
	{
		if(Ball.isInPlay)
			StartCoroutine ("WaitForDestroy");
		if(!Ball.isInPlay)
			StopCoroutine("WaitForDestroy");
	}*/

	void OnTriggerEnter(Collider col)
	{
		OnBallKilledEvent ();
		Rigidbody rb = col.attachedRigidbody;
		rb.isKinematic = true;
		StartCoroutine ("WaitForBall");
	}
		
	IEnumerator WaitForBall()
	{
		yield return new WaitForSeconds (0.3F);
		ballSpender.SpendNewBall ();
	}

	public void DestroyBall()
	{
		OnBallKilledEvent (); 

		Rigidbody rb = basketBall.GetComponent<Rigidbody> ();
		rb.isKinematic = true;

		ballSpender.SpendNewBall ();
	}
	/*
	IEnumerator WaitForDestroy()
	{
		yield return new WaitForSeconds (killTime);
		DestroyBall ();
	}*/
}
