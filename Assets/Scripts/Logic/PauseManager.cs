using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(PauseMenu))]
public class PauseManager : MonoBehaviour {
	private bool isPaused;
	public bool IsPaused{
		get{ return isPaused; }
		set{
			isPaused = value;
			if(isPaused)
				Time.timeScale = 0;
			else
				Time.timeScale = 1;
			foreach(PauseListener listener in listeners){
				listener.OnPauseChanged(value);
			}
		}
	}

	public void addListener(PauseListener newListener){
		listeners.Add(newListener);
	}

	private List<PauseListener> listeners;

	private static PauseManager instance;
	public static PauseManager Instance{
		get{
			if(instance == null){
				GameObject obj = Instantiate(new GameObject()) as GameObject;
				obj.AddComponent(typeof(PauseManager));
				instance = obj.GetComponent<PauseManager>();
			
			}
			return instance;
		}
	}

	// Use this for initialization
	void Awake () {
		listeners = new List<PauseListener>();
		IsPaused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(IsPaused){
				IsPaused = false;
			}else {
				IsPaused = true;
			}
		}
	}
}
