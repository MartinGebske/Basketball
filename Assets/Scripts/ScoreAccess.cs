using UnityEngine;
using System.Collections;

public class ScoreAccess : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		ScoreApplyer trigger = GetComponentInChildren<ScoreApplyer> ();
		trigger.ExpectCollider (other);
	}
}
