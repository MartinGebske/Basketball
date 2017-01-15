using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	[Header("Tweak Values")]

	public bool enableMusic;

	public float lowPitchRange = 0.95F;

	public float highPitchRange = 1.05F;

	[Header("Audio Clips")]

	public AudioClip levelMusic;

	public AudioClip scoreStrikeSnd; // Könnte man noch in einen Array verwandeln.

	public AudioClip scoreSndDefault;

	public AudioClip ballDestroyedSnd;

	public AudioClip ballSpawnSnd;

	public AudioClip ballThrowSnd;

	public AudioClip bounceSnd;

	public AudioClip fireworkSnd;

	[Header("Audio Sources")]

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
		levelEffectSource.pitch = 1;
		levelEffectSource.PlayOneShot (scoreStrikeSnd);
	}

	public void OnBallDestroyed()
	{
		RandomizeSfx ();
		levelEffectSource.PlayOneShot (ballDestroyedSnd);
	}

	public void OnSpawningBall()
	{
		levelEffectSource.pitch = 1;
		levelEffectSource.PlayOneShot (ballSpawnSnd);
	}

	public void OnThrowBall()
	{
		RandomizeSfx ();
		levelEffectSource.PlayOneShot (ballThrowSnd);
	}

	public void OnRegularScoring()
	{
		levelEffectSource.pitch = 1;
		levelEffectSource.PlayOneShot (scoreSndDefault);
	}

	public void OnBouncing()
	{
		RandomizeSfx ();
		levelEffectSource.PlayOneShot (bounceSnd);
	}

	public void CelebrateHighscore()
	{
		StartCoroutine (HoldBackSound ());
	}

	IEnumerator HoldBackSound()
	{
		levelEffectSource.pitch = 1;
		yield return new WaitForSeconds (1);
		levelEffectSource.PlayOneShot (fireworkSnd);
	}

	public void RandomizeSfx()
	{
		float randomPitch = Random.Range (lowPitchRange, highPitchRange);
		levelEffectSource.pitch = randomPitch;
	}
}
