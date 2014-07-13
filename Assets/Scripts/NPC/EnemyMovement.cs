using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	/// <summary>
	/// The direction the object will move
	/// </summary>
	public Vector2 direction;

	/// <summary>
	/// The speed at which he object will move.
	/// </summary>
	public Vector2 speed;

	private bool bouncing = false;

	/// <summary>
	///	Should the object flip in x direction when it hits the screen border?
	/// </summary>
	public bool isFlipableX;

	public float rammingDamage = 0f;

	void FixedUpdate(){
		if(!bouncing)
			this.rigidbody2D.velocity = new Vector2(direction.x * speed.x, direction.y * speed.y);
	}

	protected virtual void FlipX(){
		this.direction = new Vector2(-direction.x, direction.y);
		this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}

	protected virtual void OnTriggerEnter2D(Collider2D collider) {
		if(isFlipableX){
			if(this.rigidbody2D.velocity.x > 0 && collider.tag == "BoundX+")
				FlipX();
			else if(this.rigidbody2D.velocity.x < 0 && collider.tag == "BoundX-")
				FlipX();
		}
	}

	protected virtual void OnCollisionStay2D(Collision2D collision){
		if(collision.gameObject.tag == "Inimigo" && !bouncing){
			if(Mathf.Abs(rigidbody2D.velocity.x) > 0)
				if(collision.transform.position.y > this.transform.position.y){
					StartCoroutine( Bounce(new Vector2(0, -300) ) );
				}else {
					StartCoroutine( Bounce(new Vector2(0, 300) ) );
				}
			else{
				if(collision.transform.position.x > this.transform.position.x){
					StartCoroutine( Bounce(new Vector2(-300, 0) ) );
				}else {
					StartCoroutine( Bounce(new Vector2(300, 0) ) );
				}
			}
		}
	}

	protected virtual void OnCollisionEnter2D(Collision2D collider){
		if(collider.gameObject.tag == "Player" && rammingDamage > 0){
			HealthBehaviour targetHealth = collider.gameObject.GetComponent<HealthBehaviour>();
			if(targetHealth != null){
				targetHealth.TakeDamage(rammingDamage);
			}
		}
	}

	IEnumerator Bounce(Vector2 bounceForce){
		bouncing = true;
		this.rigidbody2D.AddForce(bounceForce);
		yield return null;
		bouncing = false;
	}
}
