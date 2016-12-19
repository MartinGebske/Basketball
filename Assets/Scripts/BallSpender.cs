using UnityEngine;
using System.Collections;

public class BallSpender : MonoBehaviour {

	public GameObject basketBall;

	public ParticleSystem spawnPart;

	private Renderer rend;

	public delegate void OnSpawnNewBall();
	public static event OnSpawnNewBall OnSpawnNewBallEvent;

	void OnEnabled()
	{
		Shredder.OnBallKilledEvent += this.SpendNewBall;
	}

	void OnDisabled()
	{
		Shredder.OnBallKilledEvent -= this.SpendNewBall;
	}

	void Start()
	{
		rend = basketBall.GetComponent<Renderer> ();
		rend.enabled = false;
		SpendNewBall ();
	}

	public void SpendNewBall()
	{
		spawnPart.Play ();
		OnSpawnNewBallEvent ();
		basketBall.transform.position = this.transform.position;
		StartCoroutine (WaitForBall ());
	}

	IEnumerator WaitForBall()
	{
		yield return new WaitForSeconds (2);
		Ball.isInPlay = false;
		rend.enabled = true;
	}


}
