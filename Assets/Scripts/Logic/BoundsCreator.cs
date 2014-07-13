using UnityEngine;
using System.Collections;

public class BoundsCreator : MonoBehaviour {

	private Camera _camera;
	public BoxCollider2D _collider;
	
	// Use this for initialization
	void Start () {
		_camera = transform.root.GetComponentInChildren<Camera>();
		BoxCollider2D newCollider;

		newCollider = Instantiate(_collider, _camera.ViewportToWorldPoint(new Vector3(0.5f,1f,0.5f)), Quaternion.identity) as BoxCollider2D;
		newCollider.transform.parent = this.transform;
		newCollider.size = new Vector2(_camera.aspect * _camera.orthographicSize * 2, newCollider.size.y);
		newCollider.center = new Vector2(0, newCollider.size.y * .5f);
		newCollider.transform.tag = "BoundY+";

		newCollider = Instantiate(_collider, _camera.ViewportToWorldPoint(new Vector3(0.5f,0f,0.5f)), Quaternion.identity) as BoxCollider2D;
		newCollider.transform.parent = this.transform;
		newCollider.size = new Vector2(_camera.aspect * _camera.orthographicSize * 2, newCollider.size.y);
		newCollider.center = new Vector2(0, -(newCollider.size.y * .5f));
		newCollider.transform.tag = "BoundY-";

		newCollider = Instantiate(_collider, _camera.ViewportToWorldPoint(new Vector3(1f,0.5f,0.5f)), Quaternion.identity) as BoxCollider2D;
		newCollider.transform.parent = this.transform;
		newCollider.size = new Vector2(newCollider.size.x, _camera.orthographicSize * 2f);
		newCollider.center = new Vector2(newCollider.size.x * .5f, 0f);
		newCollider.transform.tag = "BoundX+";

		newCollider = Instantiate(_collider, _camera.ViewportToWorldPoint(new Vector3(0f,0.5f,0.5f)), Quaternion.identity) as BoxCollider2D;
		newCollider.transform.parent = this.transform;
		newCollider.size = new Vector2(newCollider.size.x, _camera.orthographicSize * 2f);
		newCollider.center = new Vector2(-(newCollider.size.x * .5f), 0f);
		newCollider.transform.tag = "BoundX-";

		newCollider = Instantiate(_collider, _camera.ViewportToWorldPoint(new Vector3(0.5f,1.5f,0.5f)), Quaternion.identity) as BoxCollider2D;
		newCollider.transform.parent = this.transform;
		newCollider.size = new Vector2(_camera.aspect * _camera.orthographicSize * 8, newCollider.size.y * 2);
		newCollider.center = new Vector2(0, newCollider.size.y * .5f);
		newCollider.transform.tag = "DestroyerBound";
		
		newCollider = Instantiate(_collider, _camera.ViewportToWorldPoint(new Vector3(0.5f,-.5f,0.5f)), Quaternion.identity) as BoxCollider2D;
		newCollider.transform.parent = this.transform;
		newCollider.size = new Vector2(_camera.aspect * _camera.orthographicSize * 8, newCollider.size.y * 2);
		newCollider.center = new Vector2(0, -(newCollider.size.y * .5f));
		newCollider.transform.tag = "DestroyerBound";
		
		newCollider = Instantiate(_collider, _camera.ViewportToWorldPoint(new Vector3(2f,0.5f,0.5f)), Quaternion.identity) as BoxCollider2D;
		newCollider.transform.parent = this.transform;
		newCollider.size = new Vector2(newCollider.size.x * 2, _camera.orthographicSize * 8f);
		newCollider.center = new Vector2(newCollider.size.x * .5f, 0f);
		newCollider.transform.tag = "DestroyerBound";
		
		newCollider = Instantiate(_collider, _camera.ViewportToWorldPoint(new Vector3(-1f,0.5f,0.5f)), Quaternion.identity) as BoxCollider2D;
		newCollider.transform.parent = this.transform;
		newCollider.size = new Vector2(newCollider.size.x * 2, _camera.orthographicSize * 8f);
		newCollider.center = new Vector2(-(newCollider.size.x * .5f), 0f);
		newCollider.transform.tag = "DestroyerBound";
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
