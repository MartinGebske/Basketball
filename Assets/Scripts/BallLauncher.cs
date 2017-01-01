using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

	public Camera cam;

	public GameObject basketBall;

    public float ballSpeed = 8.0f;

	public Transform grabPosition;

	public float windowOfOportunity = 2F;

	private Animator animator;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}


	public void GrabBall()
	{
		GameObject ballToGrab = GameObject.FindGameObjectWithTag ("Basketball");
		ballToGrab.transform.position = grabPosition.position;
		ballToGrab.transform.SetParent (grabPosition);
		Ball.isInPlay = true;
		animator.SetTrigger ("hasGrabbedBall");
	}


	void ShootBall()
	{
		GameObject ballToShoot = GameObject.FindGameObjectWithTag ("Basketball");
		Rigidbody rb = ballToShoot.GetComponent<Rigidbody> ();
		rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;
		rb.useGravity = true;
		ballToShoot.transform.parent = null;

	}
}