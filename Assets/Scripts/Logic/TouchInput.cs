using UnityEngine;
using System.Collections;
using TouchScript.Gestures;
using TouchScript.Gestures.Simple;

[RequireComponent(typeof(Camera))]
[RequireComponent(typeof(MetaGesture))]
public class TouchInput : MonoBehaviour {

	private Camera _camera;
	public PlayerMovement jogador;
	public ParticleSystem touchEndCursor;
	// Use this for initialization
	void Start () {
		var metaGesture = GetComponent<MetaGesture>();
		metaGesture.TouchPointBegan += OnTouchEvent;
		metaGesture.TouchPointMoved += OnTouchEvent;
		metaGesture.TouchPointEnded += OnTouchEnded;
		metaGesture.TouchPointCancelled += OnTouchEnded;

		_camera = GetComponent<Camera>();
	}
	
	private void OnTouchEvent(object sender, MetaGestureEventArgs e)
	{
		jogador.Target = _camera.ScreenToWorldPoint( new Vector3(e.TouchPoint.Position.x,
		                                                        e.TouchPoint.Position.y,
		                                                        jogador.transform.position.z) );
	}
	
	private void OnTouchEnded(object sender, MetaGestureEventArgs e)
	{
		if (((MetaGesture)sender).State == Gesture.GestureState.Ended){
			touchEndCursor.transform.position = _camera.ScreenToWorldPoint( new Vector3(e.TouchPoint.Position.x,
			                                                                            e.TouchPoint.Position.y,
			                                                                            jogador.transform.position.z) );
			touchEndCursor.Emit(15);
		}
	}
}
