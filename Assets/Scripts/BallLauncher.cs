using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

	public GameObject ball;

    public float ballSpeed = 8.0f;

	public float windowOfOportunity = 2F;

	public static bool ballLives;

	private Camera cam;


    void Start () 
	{
		cam = GetComponentInChildren<Camera>();
	}
	

	void Update () 
	{

		windowOfOportunity -= Time.deltaTime;
		print (windowOfOportunity);


		if (windowOfOportunity <= 0 && !ballLives)
        {
			ShootBall ();
			windowOfOportunity = 2;
        }
    }
	void ShootBall()
	{
		GameObject instance = Instantiate(ball);
		instance.transform.position = transform.position;

		Rigidbody rb = instance.GetComponent<Rigidbody>();
		rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;
		ballLives = true;
	}
}
