using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public bool enableMusic;

	public AudioClip levelMusic;

	public AudioClip scoreStrikeSnd; // Könnte man noch in einen Array verwandeln.

	public AudioClip ballDestroyedSnd;

	public AudioClip ballSpawnSnd;

	public AudioClip ballThrowSnd;

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
		Shredder.OnBallKilledEvent += this.OnBallDestroyed;
		BallSpender.OnSpawnNewBallEvent += this.OnSpawningBall;
		BallLauncher.OnShootBallEvent += this.OnThrowBall;
	}

	void OnDisable()
	{
		Shredder.OnBallKilledEvent -= this.OnBallDestroyed;
		BallSpender.OnSpawnNewBallEvent -= this.OnSpawningBall;
		BallLauncher.OnShootBallEvent += this.OnThrowBall;
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
	
}
