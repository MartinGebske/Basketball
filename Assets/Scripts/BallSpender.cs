using UnityEngine;
using System.Collections;

public class BallSpender : MonoBehaviour {

	public GameObject basketBall;

	public ParticleSystem spawnPart;

	private Renderer rend;

	private AudioSource audioSource;

	void Start()
	{
		audioSource = GetComponent<AudioSource> ();
		rend = basketBall.GetComponent<Renderer> ();
		rend.enabled = false;
		SpendNewBall ();
	}

	public void SpendNewBall()
	{
		spawnPart.Play ();
		audioSource.Play ();
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
