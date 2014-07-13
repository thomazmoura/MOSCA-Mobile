using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5;
	private Vector3 target;
	private Animator animator;

	public Vector3 Target{
		get{return target;}
		set{target=value;}
	}

	// Use this for initialization
	void Start(){
		target = transform.position;
		animator = GetComponent<Animator>();
	}


	void Update () {
		/*if(Input.touchCount == 1) {
			target = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
			target = new Vector3(target.x, target.y, transform.position.z);
		}*/
	}

	void FixedUpdate(){
		Vector3 direction = target - transform.position;
		direction = direction.normalized;
		if(Vector3.Distance(this.transform.position, target) >= direction.magnitude * speed * Time.fixedDeltaTime){
			rigidbody2D.velocity = new Vector2(direction.x * speed, direction.y * speed);
		}else{
			transform.position =  target;
			rigidbody2D.velocity = Vector3.zero;
		}
		animator.SetFloat("Speed", rigidbody2D.velocity.x);
	}

	void OnTriggerEnter2D(Collider2D collider){
		//If player is moving away from the screen horizontally, stop him
		if( (collider.tag == "BoundX+" && rigidbody2D.velocity.x > 0) ||
		   		(collider.tag == "BoundX-" && rigidbody2D.velocity.x < 0) ){
			target = new Vector2( transform.position.x, target.y);
		}
		if( (collider.tag == "BoundY+" && rigidbody2D.velocity.y > 0) ||
		         (collider.tag == "BoundY-" && rigidbody2D.velocity.y < 0) ){
			target = new Vector2( target.x, transform.position.y);
		}
	}

	void OnTriggerStay2D(Collider2D collider){
		//If player is moving away from the screen horizontally, stop him
		if(collider.tag == "BoundX+" && rigidbody2D.velocity.x > 0){
			transform.position = new Vector3(transform.position.x-.1f, transform.position.y, transform.position.z);
			target = new Vector2( transform.position.x, target.y);
		}else if(collider.tag == "BoundX-" && rigidbody2D.velocity.x < 0){
			transform.position = new Vector3(transform.position.x+.1f, transform.position.y, transform.position.z);
			target = new Vector2( transform.position.x, target.y);
		}

		if(collider.tag == "BoundY+" && rigidbody2D.velocity.y > 0){
			transform.position = new Vector3(transform.position.x, transform.position.y-.1f, transform.position.z);
			target = new Vector2( target.x, transform.position.y);
		}else if(collider.tag == "BoundY-" && rigidbody2D.velocity.y < 0){
			transform.position = new Vector3(transform.position.x, transform.position.y+.1f, transform.position.z);
			target = new Vector2( target.x, transform.position.y);
		}
	}
}
