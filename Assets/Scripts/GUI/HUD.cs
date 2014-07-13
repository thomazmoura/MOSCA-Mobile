using UnityEngine;
using System.Collections;

public class HUD : MonoBehaviour {

	public PlayerHealthBehaviour playerHealth;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnGUI(){
		GUIStyle lifeStyle = new GUIStyle(GameSkin.gameStyle);
		lifeStyle.alignment = TextAnchor.MiddleLeft;
		GUI.Label(new Rect(0,0,10,35), "Life: " + playerHealth.CurrentHealth, lifeStyle);
		GUI.Label(new Rect(0,40,10,35), "Score: " + Score.CurrentScore, lifeStyle);
	}
}
