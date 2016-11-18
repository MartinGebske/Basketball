using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager DefaultInstance{
		get{ return ThisInstance; }
	}

	private static ScoreManager ThisInstance = null;

    public static int score = 0;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
		if (ThisInstance != null) {
			DestroyImmediate (gameObject);
			return;
		}
		ThisInstance = this;
	}

	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void IncrementScore(int amount)
    {
        score += amount;
        AudioSource source = GetComponent<AudioSource>();
        source.Play();
    }
}
