using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

	public Camera cam;

	public GameObject basketBall;

    public float ballSpeed = 8.0f;

	public Transform grabPosition;

	public float windowOfOportunity = 2F;

	private enum States { IDLE, GRABBING, SHOOTING }

	private States StateMachine;
		
	void Update () 
	{

		switch (StateMachine) 
		{

		case States.IDLE:

			// Do nothing
			break;
		
		case States.GRABBING:
			windowOfOportunity -= Time.deltaTime;

			if (windowOfOportunity <= 0) {
				StateMachine = States.SHOOTING;
				windowOfOportunity = 2;
			}
				break;
			
		case States.SHOOTING:
			ShootBall ();
			break;
		}
    }

	public void GrabBall()
	{
		GameObject ballToGrab = GameObject.FindGameObjectWithTag ("Basketball");
		ballToGrab.transform.position = grabPosition.position;
		ballToGrab.transform.SetParent (grabPosition);
		Ball.isInPlay = true;
		StateMachine = States.GRABBING;
	}


	void ShootBall()
	{
		GameObject ballToShoot = GameObject.FindGameObjectWithTag ("Basketball");
		Rigidbody rb = ballToShoot.GetComponent<Rigidbody> ();
		rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;
		rb.useGravity = true;
		ballToShoot.transform.parent = null;
		StateMachine = States.IDLE;
	}
}