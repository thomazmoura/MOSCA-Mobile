using UnityEngine;
using System.Collections;

public class Profiler : MonoBehaviour {

	public Vector2 fpsLabelPosition;
	public Vector2 fpsLabelScale;

	private Rect position;
	private string fps = "0 FPS";

	// Use this for initialization
	void Start () {
		position = new Rect(
			Camera.main.ViewportToScreenPoint(new Vector3(fpsLabelPosition.x,0, 10)).x,
			Camera.main.ViewportToScreenPoint(new Vector3(0,fpsLabelPosition.y, 10)).y,
			fpsLabelScale.x,
			fpsLabelScale.y
		);

		StartCoroutine(CountFPS());
	}

	IEnumerator CountFPS(){
		while(true){
			int currentFPS = 0;
			for(float i = 0; i < 1; i+= Time.deltaTime){
				currentFPS++;
				yield return null;
			}
			fps = currentFPS.ToString() + " FPS";
		}
	}

	void OnGUI(){
		GUI.Label(position, fps, GameSkin.gameStyle);
	}
}
