using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

	public GameObject basketBall;

    public float ballSpeed = 8.0f;

	public float windowOfOportunity = 2F;

	public static bool ballLives;

	private Camera cam;

	private Shredder shredder;

    void Start () 
	{
		cam = GetComponentInChildren<Camera>();
		shredder = FindObjectOfType<Shredder> ();
	}
	

	void Update () 
	{

		windowOfOportunity -= Time.deltaTime;


		if (windowOfOportunity <= 0 && !ballLives)
        {
			ShootBall ();
			windowOfOportunity = 2;
        }
		if (windowOfOportunity < -10 && ballLives)
			shredder.DestroyBall ();
    }
	void ShootBall()
	{
		GameObject instance = Instantiate(basketBall);
		instance.transform.position = transform.position;

		Rigidbody rb = instance.GetComponent<Rigidbody>();
		rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;
		ballLives = true;
	}
}
