using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

	/// <summary>
	/// Velocidade do tiro
	/// </summary>
	public Vector2 speed;
	/// <summary>
	/// Direcao do tiro
	/// </summary>
	public Vector2 direction;
	/// <summary>
	/// A tag do alvo (quais objetos ele ira atingir)
	/// </summary>
	public TargetTag targetTag;
	/// <summary>
	/// Quanto dano ele ira causar
	/// </summary>
	public float damage;

	/// <summary>
	/// Tags validas de alvo (possiveis alvos que o tiro pode atingir
	/// </summary>
	public enum TargetTag
	{
		Inimigo,
		Player
	};

	void FixedUpdate () {
		rigidbody2D.velocity = new Vector2(direction.x * speed.x, direction.y * speed.y);
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		//Verifica se o objeto com o qual o tiro colidiu possui a sua tag alvo
		if(collider.tag == targetTag.ToString()){
			//Identifica o HealThBehaviour do objeto atingido
			HealthBehaviour enemyHealth = collider.GetComponent<HealthBehaviour>();
			if(enemyHealth != null){
				//Reduz o life do objeto atingido e destroi o tiro em seguida
				enemyHealth.TakeDamage(damage);
				this.Destroy(gameObject);
			}
		}
	}
}
