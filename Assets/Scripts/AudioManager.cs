using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public bool enableMusic;

	public AudioClip levelMusic;

	public AudioClip scoreStrikeSnd; // Könnte man noch in einen Array verwandeln.

	public AudioClip scoreSndDefault;

	public AudioClip ballDestroyedSnd;

	public AudioClip ballSpawnSnd;

	public AudioClip ballThrowSnd;

	public AudioClip bounceSnd;

	public AudioClip fireworkSnd;

	public AudioSource musicSource;

	public AudioSource levelEffectSource;

	public static AudioManager manager {
		get {return thisAudioManager;}
	}

	public static AudioManager thisAudioManager = null;

	void Awake()
	{
		if (thisAudioManager != null) {
			Destroy (gameObject);
		}
		thisAudioManager = this;
		DontDestroyOnLoad (gameObject);
	}

	void OnEnable()
	{
		PlayerPrefsManager.OnHighscoreEvent += this.CelebrateHighscore;
		Shredder.OnBallKilledEvent += this.OnBallDestroyed;
		BallSpender.OnSpawnNewBallEvent += this.OnSpawningBall;
		BallLauncher.OnShootBallEvent += this.OnThrowBall;
		DetectScoring.OnScoreEvent += this.OnRegularScoring;
		Bouncing.OnCollisionEvent += this.OnBouncing;
	}

	void OnDisable()
	{
		PlayerPrefsManager.OnHighscoreEvent -= this.CelebrateHighscore;
		Shredder.OnBallKilledEvent -= this.OnBallDestroyed;
		BallSpender.OnSpawnNewBallEvent -= this.OnSpawningBall;
		BallLauncher.OnShootBallEvent -= this.OnThrowBall;
		DetectScoring.OnScoreEvent -= this.OnRegularScoring;
		Bouncing.OnCollisionEvent += this.OnBouncing;
	}

	void Start () 
	{
		if (enableMusic) {
			musicSource.clip = levelMusic;
			musicSource.Play ();
		}

		if (levelEffectSource != null) {
			return;
		}
	}

	public void OnPlayScoreStrike()
	{
		levelEffectSource.PlayOneShot (scoreStrikeSnd);
	}

	public void OnBallDestroyed()
	{
		levelEffectSource.PlayOneShot (ballDestroyedSnd);
	}

	public void OnSpawningBall()
	{
		levelEffectSource.PlayOneShot (ballSpawnSnd);
	}

	public void OnThrowBall()
	{
		levelEffectSource.PlayOneShot (ballThrowSnd);
	}

	public void OnRegularScoring()
	{
		levelEffectSource.PlayOneShot (scoreSndDefault);
	}

	public void OnBouncing()
	{
		levelEffectSource.PlayOneShot (bounceSnd);
	}

	public void CelebrateHighscore()
	{
		StartCoroutine (HoldBackSound ());
	}

	IEnumerator HoldBackSound()
	{
		yield return new WaitForSeconds (1);
		levelEffectSource.PlayOneShot (fireworkSnd);
	}
}
