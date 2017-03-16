using UnityEngine;
using System.Collections;

public class ScoreApplyer : MonoBehaviour 
{
	Collider expectedCollider;

	public int basketNumber;

	public delegate void OnBallPasses(int number);
	public static event OnBallPasses OnBallPassEvent;


	public void ExpectCollider(Collider other)
	{
		expectedCollider = other;
	}

	void OnTriggerEnter(Collider otherCollider)
	{
		if (otherCollider == expectedCollider) {
			if (OnBallPassEvent != null) {
				OnBallPassEvent (basketNumber);
			}
		}
	}
}
