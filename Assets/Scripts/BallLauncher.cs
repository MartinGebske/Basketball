using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

	public Camera cam;

    public float ballSpeed = 8.0f;

	public Transform grabPosition;

	public float windowOfOportunity = 2F;

	private Animator animator;

	private GameObject basketBall;

	private Rigidbody rb;

	public void GrabBall()
	{
		FindBall ();
		animator = GetComponent<Animator> ();
		basketBall.transform.position = grabPosition.position;
		basketBall.transform.SetParent (grabPosition);
		Ball.isInPlay = true;
		animator.SetTrigger ("hasGrabbedBall");
	}


	void ShootBall()
	{
		FindBall();
		rb.isKinematic = false;
		rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;

		rb.useGravity = true;
		basketBall.transform.parent = null;
	}

	void FindBall()
	{
		basketBall = GameObject.FindGameObjectWithTag ("Basketball");
		rb = basketBall.GetComponent<Rigidbody> ();
	}
}