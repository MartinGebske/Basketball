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
	}

	void OnTriggerEnter(Collider col)
	{
		if (OnBallKilledEvent != null) {
			OnBallKilledEvent ();
		}

		Rigidbody rb = col.attachedRigidbody;
		if (rb != null) {
			rb.isKinematic = true;
		}
		StartCoroutine ("WaitForBall");
	}
		
	IEnumerator WaitForBall()
	{
		yield return new WaitForSeconds (0.3F);
		ballSpender.SpendNewBall ();
	}

	public void DestroyBall()
	{
		if (OnBallKilledEvent != null) {
			OnBallKilledEvent (); 
		}

		Rigidbody rb = basketBall.GetComponent<Rigidbody> ();
		if (rb != null) {
			rb.isKinematic = true;
		}
		ballSpender.SpendNewBall ();
	}
}
