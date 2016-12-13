﻿using UnityEngine;
using System.Collections;

public class Shredder : MonoBehaviour 
{
	[Range(5,10)]public float killTime;

	private BallSpender ballSpender;

	void Start()
	{
		ballSpender = FindObjectOfType<BallSpender> ();
		if (killTime < 5)
			killTime = 5;
	}

	void Update()
	{
		if(Ball.isInPlay)
			StartCoroutine ("WaitForDestroy");
		if(!Ball.isInPlay)
			StopCoroutine("WaitForDestroy");
			
	}

	void OnTriggerEnter(Collider col)
	{
		Rigidbody rb = col.attachedRigidbody;
		rb.isKinematic = true;
		Ball.scoreStreak = -1;
		ballSpender.SpendNewBall ();
	}
		
	public void DestroyBall()
	{
		GameObject basketBall = GameObject.FindGameObjectWithTag ("Basketball");
		Ball.scoreStreak = -1;
		Rigidbody rb = basketBall.GetComponent<Rigidbody> ();
		rb.isKinematic = true;
		ballSpender.SpendNewBall ();

	}

	IEnumerator WaitForDestroy()
	{
		yield return new WaitForSeconds (killTime);
		DestroyBall ();
	}
}
