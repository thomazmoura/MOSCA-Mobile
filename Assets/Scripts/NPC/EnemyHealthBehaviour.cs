using UnityEngine;
using System.Collections;

public class EnemyHealthBehaviour : HealthBehaviour {

	/// <summary>
	/// The amount of score this enemy will give the player when killed
	/// </summary>
	public int deathScore;
	/// <summary>
	/// The amount of time the enemy shall take "flashing" when hit
	/// </summary>
	public float flashDelay;

	private SpriteRenderer _renderer;

	protected override void Start ()
	{
		flashDelay = .1f;
		base.Start ();
		_renderer = GetComponent<SpriteRenderer>();
	}

	public override void TakeDamage (float damage)
	{
		base.TakeDamage (damage);
		StartCoroutine(DamageFlash());
	}

	public override void Die ()
	{
		Score.AddScore(deathScore);
		base.Die ();
	}

	IEnumerator DamageFlash(){
		_renderer.color = new Color(1f, 1f, 1f, .5f);
		for(float delay = 0; delay < flashDelay; delay += Time.deltaTime){
			yield return null;
		}
		_renderer.color = new Color(1f, 1f, 1f, 1f);
	}
}
