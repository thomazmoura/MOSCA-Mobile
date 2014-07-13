using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		if(PauseManager.Instance.IsPaused){
			Vector2 buttonSize = new Vector2(150, 50);
			if(GUI.Button( new Rect(GameSkin.screenCenter.x-(buttonSize.x/2),
			                     GameSkin.screenCenter.y-(buttonSize.y*2),
			                     buttonSize.x, buttonSize.y),
			           "Resume")){
				PauseManager.Instance.IsPaused = false;
			}
			
			if( GUI.Button( new Rect(GameSkin.screenCenter.x-(buttonSize.x/2),
			                     GameSkin.screenCenter.y,
			                     buttonSize.x, buttonSize.y),
			           "Main Menu") ) {
				Application.LoadLevel(0);
			}
		}
	}
}
