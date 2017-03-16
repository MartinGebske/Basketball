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

	static readonly int anim_HasGrabbedBall = Animator.StringToHash("hasGrabbedBall");

	public delegate void OnShootBall();
	public static event OnShootBall OnShootBallEvent;

	void Start()
	{
		animator = GetComponent<Animator> ();
	}

	public void GrabBall()
	{
		FindBall ();

			basketBall.transform.position = grabPosition.position;
			basketBall.transform.SetParent (grabPosition);
		
			
		Ball.isInPlay = true;

		if (animator != null) {
			animator.SetTrigger (anim_HasGrabbedBall);
		}
	}
		
	void ShootBall()
	{
		FindBall();

		if (rb != null) {
			rb.isKinematic = false;
			rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;

			rb.useGravity = true;
			basketBall.transform.parent = null;
		}

		if (OnShootBallEvent != null) {
			OnShootBallEvent();
		}
	}

	void FindBall()
	{
		basketBall = GameObject.FindGameObjectWithTag ("Basketball");

		if (basketBall != null) {
			rb = basketBall.GetComponent<Rigidbody> ();
		}
	}
}