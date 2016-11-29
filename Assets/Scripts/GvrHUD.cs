using UnityEngine;
using UnityEngine.UI;

//[RequireComponent(typeof(Text))]
public class GvrHUD : MonoBehaviour 
{
  	public Camera cam;

	public Image interactionRing;

	private Animator animator;

	public Text textField;



 	void Awake() 
	{
		//textField = FindObjectOfType<Text>();
		animator = GetComponent<Animator> ();
		UpdateScore ();
  	}

  	void Start() 
	{
    	if (cam == null) {
       		cam = Camera.main;
    		}

    	if (cam != null) {
      	// Tie this to the camera, and do not keep the local orientation.
      		transform.SetParent(cam.GetComponent<Transform>(), true);
    		}
  	}
	public void UpdateScore()
	{
		textField.text = ScoreManager.score.ToString ();
	}
}
