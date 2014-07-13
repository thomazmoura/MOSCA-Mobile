using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	public Vector2 speed;
	public Vector2 direction;
	public TargetTag targetTag;
	public float damage;

	public enum TargetTag
	{
		Inimigo,
		Player
	};

	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2(direction.x * speed.x, direction.y * speed.y);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		if(collider.tag == targetTag.ToString()){
			HealthBehaviour enemyHealth = collider.GetComponent<HealthBehaviour>();
			if(enemyHealth != null){
				enemyHealth.TakeDamage(damage);
				this.Destroy(gameObject);
			}
		}
	}
}
