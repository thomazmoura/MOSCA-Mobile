using UnityEngine;
using System.Collections;

public class GameSkin : MonoBehaviour {

	public static GUIStyle gameStyle;
	public GUIStyle gameFontStyle;

	public static Vector2 screenSize;
	public static Vector2 screenCenter;

	void Start(){
		gameStyle = gameFontStyle;
		screenSize = new Vector2(Camera.main.pixelWidth, Camera.main.pixelHeight);
		screenCenter = new Vector2(screenSize.x/2, screenSize.y/2);
	}

}
