using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RandomizedAppearing : MonoBehaviour 
{
	[Range( 0,5)] [Tooltip ("Gibt an wann der Timer zum ersten Mal startet.")]
	public float initialTime;

	public float minInvisibleTime;
	public float maxInvisibleTime;

	public float minShowTime;
	public float maxShowTime;

	float invisibleTime;
	float showTime;

	[Tooltip("Disable by default!")] public GameObject childObjects; 

	void Start()
	{
		Invoke ("InitializeLoop", initialTime);
	}
		
	void InitializeLoop()
	{
		invisibleTime = RandomizeValue (minInvisibleTime, maxInvisibleTime);
		showTime = RandomizeValue(minShowTime, maxShowTime);
		StartCoroutine (MainLoop());
	}
		
	float RandomizeValue(float min, float max)
	{
		float randomizedValue = Random.Range (min, max);
		return randomizedValue;
	}

	IEnumerator MainLoop()
	{
		yield return new  WaitForSeconds (invisibleTime);
		childObjects.SetActive (true);

		if (childObjects.activeInHierarchy) {
			yield return new WaitForSeconds (showTime);
			if (DetectScoring.currentScoreRoutine)
				yield return new WaitForSeconds (1);
			childObjects.SetActive (false);
			InitializeLoop ();
		}
	}
}
