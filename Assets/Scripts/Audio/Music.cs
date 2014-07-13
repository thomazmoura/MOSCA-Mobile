using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class Music : MonoBehaviour, PauseListener {

	public AudioClip[] menuSongs;
	public AudioClip[] levelSongs;
	public AudioClip[] bossSongs;

	private bool isPaused;

	public int currentSong;

	public CurrentSongType currentSongType;

	public enum CurrentSongType{
		Menu,
		Level,
		Boss
	}


	// Use this for initialization
	void Start () {
		PauseManager.Instance.addListener(this);
	}
	
	// Update is called once per frame
	void Update () {
		//Caso a musica ja esteja tocando ou o jogo esteja pausado pule todo o resto do codigo
		if(audio.isPlaying || isPaused)
			return;

		nextSong();
	}

	public void OnPauseChanged(bool isPaused){
		if(isPaused){
			audio.Pause();
			this.isPaused = isPaused;
		}else{
			audio.Play();
			this.isPaused = isPaused;
		}
	}

	public void nextSong(){
		switch(currentSongType){
		case CurrentSongType.Menu:
			if(menuSongs.Length > 0){
				currentSong = Randomizer.NextInt(menuSongs.Length);
				audio.clip = menuSongs[currentSong];
				audio.Play();
			}
			break;
		case CurrentSongType.Level:
			if(levelSongs.Length > 0){
				currentSong = Randomizer.NextInt(levelSongs.Length);
				audio.clip = levelSongs[currentSong];
				audio.Play();
			}
			break;
		case CurrentSongType.Boss:
			if(bossSongs.Length > 0){
				audio.PlayOneShot(bossSongs[currentSong]);
				currentSong = Randomizer.NextInt(menuSongs.Length);
			}
			break;
		}
	}
}
