using UnityEngine;
using System.Collections;

/// <summary>
/// Especializacao do HealthBehaviour para inimigos
/// </summary>
public class EnemyHealthBehaviour : HealthBehaviour {

	/// <summary>
	/// Quantos pontos o inimigo ira dar ao jogador ao ser morto
	/// </summary>
	public int deathScore;
	/// <summary>
	/// A quantidade de tempo que o inimigo ira piscar (efeito visual para indicar dano)
	/// </summary>
	public float flashDelay = .1f;

	/// <summary>
	/// O renderizador do sprite do inimigo em questao
	/// </summary>
	private SpriteRenderer _renderer;

	protected override void Start ()
	{
		base.Start ();
		_renderer = GetComponent<SpriteRenderer>();
	}

	/// <summary>
	/// Metodo da acao de dano
	/// </summary>
	/// <param name="damage">Quantidade de dano.</param>
	public override void TakeDamage (float damage)
	{
		base.TakeDamage (damage);
		StartCoroutine(DamageFlash());
	}

	/// <summary>
	/// Metodo da acao de morte
	/// </summary>
	public override void Die ()
	{
		//Acrescenta a quantidade de pontos ao placar do jogador
		Score.AddScore(deathScore);
		base.Die ();
	}

	/// <summary>
	/// Metodo que faz o inimigo "piscar" (torna ele transparente e em seguida opaco novamente)
	/// </summary>
	IEnumerator DamageFlash(){
		_renderer.color = new Color(1f, 1f, 1f, .5f);
		for(float delay = 0; delay < flashDelay; delay += Time.deltaTime){
			yield return null;
		}
		_renderer.color = new Color(1f, 1f, 1f, 1f);
	}
}
