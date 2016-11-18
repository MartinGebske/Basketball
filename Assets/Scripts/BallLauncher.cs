using UnityEngine;
using System.Collections;

public class BallLauncher : MonoBehaviour {

	public GameObject ball;
    public float ballSpeed = 8.0f;
	public static bool ballLives;
	Camera cam;


    // Use this for initialization
    void Start () 
	{
		cam = GetComponentInChildren<Camera>();
	}
	

	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)&& !ballLives)
        {
            GameObject instance = Instantiate(ball);
            instance.transform.position = transform.position;
            
			Rigidbody rb = instance.GetComponent<Rigidbody>();
            rb.velocity = cam.transform.rotation * Vector3.forward * ballSpeed;
			ballLives = true;
        }
    }
}
