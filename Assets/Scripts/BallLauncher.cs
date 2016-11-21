using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

	public enum States { GRABBING, SHOOTING }

    public float ballSpeed = 8.0f;

	public float windowOfOportunity = 2F;

	public Transform grabPosition;

	private Camera cam;

	private Shredder shredder;
	private Ball ball;

	States StateMachine;

	States ShootState = States.SHOOTING;
	States GrabState = States.GRABBING;

    void Start () 
	{
		
		cam = GetComponentInChildren<Camera>();
		shredder = FindObjectOfType<Shredder> ();
	}


	void Update () 
	{
		ball = GameObject.FindObjectOfType<Ball> ();

		if (StateMachine == ShootState) {
			windowOfOportunity -= Time.deltaTime;
			if (windowOfOportunity <= 0) {
				ShootBall ();
			}	
		}

		if (windowOfOportunity < -10 && ball == null) {
			shredder.DestroyBall ();
			windowOfOportunity = 2;
		}
    }

	public void GrabBall()
	{
		ball.transform.position = grabPosition.transform.position;
		Rigidbody rb = ball.GetComponent<Rigidbody>();
		rb.useGravity = false;
		ball.transform.SetParent (grabPosition);
		StateMachine = ShootState;
	}


	void ShootBall()
	{
			Rigidbody rb = ball.GetComponent<Rigidbody>();
			rb.useGravity = true;
			rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;
	}
	void ResetBall()
	{
		
	}
}
