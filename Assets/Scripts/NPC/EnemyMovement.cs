using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	/// <summary>
	/// A direcao na qual o inimigo ira se mover
	/// </summary>
	public Vector2 direction;

	/// <summary>
	/// A velocidade na qual o inimigo ira se mover
	/// </summary>
	public Vector2 speed;

	private bool bouncing = false;

	/// <summary>
	///	O inimigo deve inverter sua direcao caso colida com a borda lateral?
	/// </summary>
	public bool isFlipableX;

	/// <summary>
	/// A quantidade de dano que o inimigo ira causar ao se colidir com o jogador (por padrao 0)
	/// </summary>
	public float rammingDamage = 0f;

	void FixedUpdate(){
		if(!bouncing)
			this.rigidbody2D.velocity = new Vector2(direction.x * speed.x, direction.y * speed.y);
	}

	/// <summary>
	/// Metodo para inverter a direcaoX do jogador
	/// </summary>
	protected virtual void FlipX(){
		this.direction = new Vector2(-direction.x, direction.y);
		this.transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
	}
	
	protected virtual void OnTriggerEnter2D(Collider2D collider) {
		//Colisao com as bordas laterais no caso do inimigo ser invertido ao colidir
		if(isFlipableX){
			if(this.rigidbody2D.velocity.x > 0 && collider.tag == "BoundX+")
				FlipX();
			else if(this.rigidbody2D.velocity.x < 0 && collider.tag == "BoundX-")
				FlipX();
		}
	}

	protected virtual void OnCollisionStay2D(Collision2D collision){
		//Caso colida com outro inimigo e nao ja esteja "quicando"
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
		//Colisao com o jogador (caso o inimigo em questao cause dano)
		if(collider.gameObject.tag == "Player" && rammingDamage > 0){
			HealthBehaviour targetHealth = collider.gameObject.GetComponent<HealthBehaviour>();
			if(targetHealth != null){
				targetHealth.TakeDamage(rammingDamage);
			}
		}
	}

	/// <summary>
	/// Metodo para fazer o inimigo "quicar" ao colidir com outro - Ao colidir
	///  ele ativa o bouncing e nao inverte a sua direcao ate que ele seja desativado
	///  (no proximo update).
	/// </summary>
	/// <param name="bounceForce">Bounce force.</param>
	IEnumerator Bounce(Vector2 bounceForce){
		bouncing = true;
		this.rigidbody2D.AddForce(bounceForce);
		yield return null;
		bouncing = false;
	}
}
