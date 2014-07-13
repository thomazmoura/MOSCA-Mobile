using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Music musicPlayer;

	void OnGUI(){
		Vector2 buttonSize = new Vector2(150, 50);
		if(GUI.Button( new Rect(GameSkin.screenCenter.x-(buttonSize.x/2),
		                        GameSkin.screenCenter.y-(buttonSize.y*2),
		                        buttonSize.x, buttonSize.y),
		              "Iniciar Jogo")){
			Application.LoadLevel(1);
		}
		string btnMessage;
		if(musicPlayer.audio.mute)
			btnMessage = "Music Off";
		else
			btnMessage = "Music On";


		if( GUI.Button( new Rect(GameSkin.screenCenter.x-(buttonSize.x/2),
		                         GameSkin.screenCenter.y,
		                         buttonSize.x, buttonSize.y),
		               btnMessage) ) {
			if(musicPlayer.audio.mute){
				musicPlayer.audio.mute = false;
			}else{
				musicPlayer.audio.mute = true;
			}
		}

		if( GUI.Button( new Rect(GameSkin.screenCenter.x-(buttonSize.x/2),
		                         GameSkin.screenCenter.y+(buttonSize.y*2),
		                         buttonSize.x, buttonSize.y),
		               "Quit game") ) {
			Application.Quit();
		}

	}
}
