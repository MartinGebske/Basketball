using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	// TODO: Muss auf jeden Fall ein Singleton werden!!!!  
	public bool enableMusic;

	public AudioClip levelMusic;
	public AudioClip scoreStrikeSnd; // Könnte man noch in einen Array verwandeln.
	public AudioClip ballDestroyedSnd;
	public AudioClip ballSpawnSnd;

	public AudioSource musicSource;

	public AudioSource levelEffectSource;

	void OnEnable()
	{
		BallStreakEvents.OnScoreStrikeEvent += this.OnPlayScoreStrike;
		Shredder.OnBallKilledEvent += this.OnBallDestroyed;
		BallSpender.OnSpawnNewBallEvent += this.OnSpawningBall;
	}

	void OnDisable()
	{
		BallStreakEvents.OnScoreStrikeEvent -= this.OnPlayScoreStrike;
		Shredder.OnBallKilledEvent -= this.OnBallDestroyed;
		BallSpender.OnSpawnNewBallEvent -= this.OnSpawningBall;
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

	
}
