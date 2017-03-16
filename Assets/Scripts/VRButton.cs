using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class VRButton : MonoBehaviour, IGvrGazeResponder 
{
	public string sceneToLoad;

	public string playerFeedback;

	public ParticleSystem selectionPart;

	public TextMeshProUGUI infoText;

	public GameObject buttonObject;

	public Color colorStart = Color.red;
	public Color colorEnd = Color.green;
	public Renderer[] rend;

	//public int selectionTime;

	Vector3 startPosition;


	void Start()
	{
		selectionPart.Stop ();
		selectionPart.Clear ();

		infoText.enabled = false;

		foreach (var item in rend) {
			item.GetComponent<Renderer> ();
			item.material.color = colorStart;
		}

		startPosition = this.transform.position;
	}

	public void OnGazeEnter()
	{
		if (this != null) {
			StartCoroutine ("LiftUpAsset");
			StartCoroutine ("Countdown");
		}
		selectionPart.Play ();
	}

	public void OnGazeTrigger() 
	{
		// Nothing in here	
	}

	public void OnGazeExit()
	{
		if (this != null) {
			StopCoroutine("LiftUpAsset");
			StopCoroutine ("Countdown");

			StartCoroutine ("LowerDownAsset");
		}

	}

	IEnumerator LiftUpAsset()
	{
		if (this != null) {

			while (true) {

				infoText.text = playerFeedback;
				infoText.enabled = true;

				transform.Translate (0, 0.01F, 0, Space.World);

				foreach (var item in rend) {
					item.material.color = colorEnd;
				}

				yield return new WaitForSeconds (0.01f);

			}
		}
	}

	IEnumerator LowerDownAsset()
	{
		if (this != null) {

			infoText.enabled = false;

			buttonObject.transform.position = startPosition;

			foreach (var item in rend) {
				item.material.color = colorStart;
			}
			selectionPart.Stop ();
			selectionPart.Clear ();
			yield return new WaitForSeconds (0.01F);
		}
	}

	IEnumerator Countdown()
	{
		if (this != null) {
			for (int i = 5; i >= 0; i--) {
				if (i <= 0) {
					StopCoroutine ("LiftUpAsset");
					StopCoroutine ("LowerDownAsset");
					yield return new WaitForSeconds (0.1F);
					StartLevel ();
				}
				yield return new WaitForSeconds (1);

			}
		}
	}

	void StartLevel()
	{
		if (this != null) {

			if (sceneToLoad == "") {
				SceneManager.LoadScene (Player.lastVisitedScene);
			} else
				SceneManager.LoadScene (sceneToLoad);
		}
	}
}
