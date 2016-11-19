using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {


    public float ballSpeed = 8.0f;

	public float windowOfOportunity = 2F;

	private Camera cam;

	private Shredder shredder;
	private Ball ball;

    void Start () 
	{
		cam = GetComponentInChildren<Camera>();
		shredder = FindObjectOfType<Shredder> ();
	}
	

	void Update () 
	{

		GameObject.FindObjectOfType<Ball> ();

		print (ball);

		windowOfOportunity -= Time.deltaTime;
	
		if (windowOfOportunity <= 0 && ball != null)
        {
			ShootBall ();
			windowOfOportunity = 2;
        }
		if (windowOfOportunity < -10 && ball == null) {
			shredder.DestroyBall ();
			windowOfOportunity = 2;
		}
			
		
    }
	void ShootBall()
	{
		Rigidbody rb = ball.GetComponent<Rigidbody>();
		rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;
	}
}
